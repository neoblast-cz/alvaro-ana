using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    
    TMP_Text score;
    TMP_Text message;
    
    SpriteRenderer blackBackground;
    Animator blackBackgroundAnimator;
    Animator messageAnimator;

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

        score = GameObject.Find("UI_Score").GetComponent<TMP_Text>();
        message = GameObject.Find("UI_Message_DoNotRename").GetComponent<TMP_Text>();
        messageAnimator = GameObject.Find("UI_Message_DoNotRename").GetComponent<Animator>();
        animator = GameObject.Find("UI_DoNotRename").GetComponent<Animator>();
        GameObject blackBackgroundGO = GameObject.Find("BlackBackground_DoNotRename");
        blackBackground = blackBackgroundGO.GetComponent<SpriteRenderer>();
        blackBackground.enabled = true;
        blackBackgroundAnimator = blackBackgroundGO.GetComponent<Animator>();
        RemoveBackgroundOverlay();
        message.text = "";
    }

    
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UpdateMessageWithAnimation("test");
            
        }

    }

    public void UpdateRingsScore(int newScore, int totalNumberOfRigngs) {
        //score.color.a = 1f;
        score.text = newScore.ToString() + "/" + totalNumberOfRigngs;
    }

    public void UpdateMessage(string actualMessage) {
        message.text = actualMessage.ToString();
    }

    public void UpdateMessageWithAnimation(string actualMessage) {
        message.text = actualMessage.ToString();
        messageAnimator.SetTrigger("fadeOut");
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
}
