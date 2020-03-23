using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private float scale = 2f;

    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Player") {
            GameObject blood = (GameObject)Instantiate(GameAssets.instance.bloodPF, transform.position, transform.rotation);
            blood.transform.localScale = new Vector3(scale, scale, scale);
            GameManager.instance.RestartLevel(1f); 
        }
    }
}