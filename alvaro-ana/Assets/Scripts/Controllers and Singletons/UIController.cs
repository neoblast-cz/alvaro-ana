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
        message.text = "";
    }

    public void UpdateRingsScore(int newScore) {
        score.text = "Rings: " + newScore.ToString();
    }

    public void UpdateMessage(string actualMessage) {
        message.text = actualMessage.ToString();
    }

    public void AddBackgroundOverlay() {
        backgroundOverlay = Instantiate(GameAssets.instance.backgroundOverlayPf, Camera.main.transform.position, Quaternion.identity);
        backgroundOverlay.transform.parent = Camera.main.transform;
    }

    public void DestroyBackgroundOverlay() {
        Destroy(backgroundOverlay);
    }
}
