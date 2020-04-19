using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    TMP_Text score;
    
    SpriteRenderer blackBackground;
    Animator blackBackgroundAnimator;

    GameObject messageParent;
    GameObject messageSticky;

    private Animator animator;
    bool inventory;

    void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        //activate intro screen
        GameAssets.instance.introMenu.SetActive(true);

        score = GameObject.Find("UI_Score").GetComponent<TMP_Text>();
        messageParent = GameObject.Find("UI_Message_DoNotRename");
        animator = GameObject.Find("UI_DoNotRename").GetComponent<Animator>();
        GameObject blackBackgroundGO = GameObject.Find("BlackBackground_DoNotRename");

        blackBackground = blackBackgroundGO.GetComponent<SpriteRenderer>();
        blackBackground.enabled = true;
        blackBackgroundAnimator = blackBackgroundGO.GetComponent<Animator>();
        RemoveBackgroundOverlay();
    }

    public void UpdateRingsScore(int newScore, int totalNumberOfRigngs) {
        score.text = newScore.ToString() + "/" + totalNumberOfRigngs;
    }

    public void AddBackgroundOverlay() {
        blackBackgroundAnimator.SetTrigger("FadeIn");
    }

    public void RemoveBackgroundOverlay() {
        blackBackgroundAnimator.SetTrigger("FadeOut");
    }

    public void InventorySwitch() {
        animator.SetBool("inventory", !inventory);
        inventory = !inventory;
    }

    public void UpdateMessageWithFadeOut(string actualMessage) {
        GameObject message = Instantiate(GameAssets.instance.messagingSystemWithFadeOutPF, messageParent.transform, messageParent.transform);
        message.transform.parent = messageParent.transform;
        message.GetComponent<TMP_Text>().text = actualMessage.ToString();

        Destroy(message, 6f);
    }

    public void UpdateMessageSticky(string actualMessage, bool initiate) {
        if (initiate) {
            messageSticky = Instantiate(GameAssets.instance.messagingSystemPF, messageParent.transform, messageParent.transform);
            messageSticky.transform.parent = messageParent.transform;
            messageSticky.GetComponent<TMP_Text>().text = actualMessage.ToString();
        }
        else {
            Destroy(messageSticky);
        }
    }
}
