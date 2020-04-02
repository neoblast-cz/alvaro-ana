using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private float scale = 1f;

    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Player") {
            GameObject blood = (GameObject)Instantiate(GameAssets.instance.deathEffectPF, transform.position, transform.rotation);
            blood.transform.localScale = new Vector3(scale, scale, scale);
            Destroy(blood, 2f);
            GameManager.instance.RestartLevel(1f); 
        }
    }
}