using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCoin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            Destroy(gameObject);
            GameManager.instance.AddScore(5);
        }
    }
}
