using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    GameObject backgroundOverlay;
    TMP_Text score;
    TMP_Text message;
    SpriteRenderer spriteRenderer;
    SpriteRenderer blackBackground;
    Animator blackBackgroundAnimator;

    void Start() {
        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        score = GameObject.Find("UI_Score").GetComponent<TMP_Text>();
        message = GameObject.Find("UI_Message").GetComponent<TMP_Text>();
        GameObject blackBackgroundGO = GameObject.Find("BlackBackground_DoNotRename");
        blackBackground = blackBackgroundGO.GetComponent<SpriteRenderer>();
        blackBackground.enabled = true;
        blackBackgroundAnimator = blackBackgroundGO.GetComponent<Animator>();
        RemoveBackgroundOverlay();
        message.text = "";
    }

    public void UpdateRingsScore(int newScore) {
        score.text = "Rings: " + newScore.ToString();
    }

    public void UpdateMessage(string actualMessage) {
        message.text = actualMessage.ToString();
    }

    public void AddBackgroundOverlay() {
        
        blackBackgroundAnimator.SetTrigger("FadeIn");
    }

    public void RemoveBackgroundOverlay() {
        
        blackBackgroundAnimator.SetTrigger("FadeOut");
    }
}
