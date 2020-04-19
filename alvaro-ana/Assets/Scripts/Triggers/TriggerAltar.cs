using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAltar : MonoBehaviour
{
    bool used;

    bool startIncreasingAlpha;
    CanvasGroup localCanvasGroup;
    float increment = 0.00001f;

    void Start()
    {
        localCanvasGroup = GameAssets.instance.finalScreen.GetComponent<CanvasGroup>();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (!used){
            used = true;
            StartCoroutine(FinalAnimation(collision.gameObject));
        }
    }

    void Update() {
        if (startIncreasingAlpha){
            while (localCanvasGroup.alpha < 1f){
                localCanvasGroup.alpha = localCanvasGroup.alpha + increment;
            }
        }
    }

    IEnumerator FinalAnimation(GameObject target) {
        target.GetComponent<PlayerMovement>().PlayingMemories();
        yield return new WaitForSeconds(1f);
        CameraController.instance.StartZoomOut(3f, 20f);
        GameAssets.instance.finalScreen.SetActive(true);
        yield return new WaitForSeconds(1f);
        StartCoroutine(ChangeAlpha(0f, 1f, 10f));
    }

    IEnumerator ChangeAlpha(float v_start, float v_end, float duration) {
        float elapsed = 0.0f;
        while (elapsed < duration) {
            localCanvasGroup.alpha = Mathf.Lerp(v_start, v_end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        localCanvasGroup.alpha = v_end;
    }
}