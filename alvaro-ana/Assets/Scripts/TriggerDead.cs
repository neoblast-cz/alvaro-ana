using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDead : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Player") {
            GameManager.instance.RestartLevel();
        }
    }
}