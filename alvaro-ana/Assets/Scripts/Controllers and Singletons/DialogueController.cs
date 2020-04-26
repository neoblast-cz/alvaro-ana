using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public static DialogueController instance;

    private GameObject UIDialogueWindow;
    private TMP_Text[] UIDialogueWindowTexts;

    private NPC speakingWith;

    public Queue<string> sentences;
    public float delayBetweenLetters = 0.06f;

    [HideInInspector]
    public bool dialogueInProgress;

    void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        sentences = new Queue<string>();
    }

    public void StartDialogue(string speaker, Dialogue dialogueFromTrigger, Transform characterTransform, bool skipZooming) {
        speakingWith = characterTransform.gameObject.GetComponent<NPC>();
        // initiate
        if (!dialogueInProgress) {
            sentences.Clear();
            CreateUIWindow(characterTransform);
            UIDialogueWindowTexts[0].text = speaker;
            if (!skipZooming)
                CameraController.instance.StartZoomIn(2.5f, 4f);

            foreach (string sentence in dialogueFromTrigger.sentences)
            {
                sentences.Enqueue(sentence);
            }
            DisplayNextSentence();
        }
        dialogueInProgress = true;
    }

    public void DisplayNextSentence() {
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence) {
        UIDialogueWindowTexts[1].text = "";
        foreach (char letter in sentence.ToCharArray()) {
            UIDialogueWindowTexts[1].text += letter;
            yield return new WaitForSeconds(delayBetweenLetters);
            yield return null;
        }
    }

    private void EndDialogue() {
        DestroyUIWindow();
        CameraController.instance.StartZoomOut(2.5f, 4f);
        dialogueInProgress = false;
        speakingWith.GiveObject();
        speakingWith = null;
    }

    private void CreateUIWindow (Transform transformWhere) {
        UIDialogueWindow = Instantiate(GameAssets.instance.dialoguePf, new Vector3(transformWhere.position.x, transformWhere.position.y + 1.3f, transformWhere.position.z), transformWhere.rotation);
        UIDialogueWindow.transform.parent = gameObject.transform;
        UIDialogueWindowTexts = UIDialogueWindow.GetComponentsInChildren<TMP_Text>();
        AudioManager.instance.PlaySound(AudioManager.Sound.Talking);
        UIController.instance.UpdateMessageSticky("Press Spacebar to continue", true);
        UIController.instance.AddBackgroundOverlay();
    }

    private void DestroyUIWindow() {
        Destroy(UIDialogueWindow);
        UIController.instance.UpdateMessageSticky("", false);
        UIController.instance.RemoveBackgroundOverlay();
    }
}