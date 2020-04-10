using UnityEngine;
using System.Collections;

public class TriggerDeadWithBlood : MonoBehaviour
{
    private float fxScale = 1f;

    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Player") {
            GameObject blood = (GameObject)Instantiate(GameAssets.instance.deathEffectPF, transform.position, transform.rotation);
            blood.transform.localScale = new Vector3(fxScale, fxScale, fxScale);
            Destroy(blood, 2f);
            GameManager.instance.RestartLevel(1f);
        }
    }
}