using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public static DialogueController instance;

    private GameObject UIDialogueWindow;
    private TMP_Text[] UIDialogueWindowTexts;

    public Queue<string> sentences;

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

    public void StartDialogue(string speaker, Dialogue dialogueFromTrigger, Transform characterTransform) {
        // initiate
        if (!dialogueInProgress)
        {
            sentences.Clear();
            CreateUIWindow(characterTransform);
            UIDialogueWindowTexts[0].text = speaker;
            CameraController.instance.StartZoomIn();
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
            yield return null;
        }
    }

    private void EndDialogue() {
        DestroyUIWindow();
        CameraController.instance.StartZoomOut();
        dialogueInProgress = false;
    }

    private void CreateUIWindow (Transform transformWhere) {
        UIDialogueWindow = Instantiate(GameAssets.instance.dialoguePf, new Vector3(transformWhere.position.x, transformWhere.position.y + 1.3f, transformWhere.position.z), transformWhere.rotation);
        UIDialogueWindow.transform.parent = gameObject.transform;
        UIDialogueWindowTexts = UIDialogueWindow.GetComponentsInChildren<TMP_Text>();
        UIController.instance.UpdateMessage("Press Spacebar to continue");
        UIController.instance.AddBackgroundOverlay();
    }

    private void DestroyUIWindow() {
        Destroy(UIDialogueWindow);
        UIController.instance.UpdateMessage("");
        UIController.instance.RemoveBackgroundOverlay();
    }
}