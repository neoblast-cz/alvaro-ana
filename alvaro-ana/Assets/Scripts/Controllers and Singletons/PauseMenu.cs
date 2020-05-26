using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class PauseMenu : MonoBehaviour
{
    CanvasGroup canvas;

    void Awake() {
        canvas = GetComponent<CanvasGroup>();
    }

    void OnEnable() {
        Debug.Log("enable");

        canvas.alpha = 0f;
        LeanTween.value(gameObject, UpdateAlpha, 0, 1, 0.5f).setDelay(0.5f);
        UIController.instance.AddBackgroundOverlay();
    }

    void OnDisable() {
        Debug.Log("disable");

        canvas.alpha = 1f;
        LeanTween.value(gameObject, UpdateAlpha, 1, 0, 0.5f).setDelay(0.5f);
        UIController.instance.RemoveBackgroundOverlay();
    }

    void UpdateAlpha(float value) {
        canvas.alpha = value;
    }
}
