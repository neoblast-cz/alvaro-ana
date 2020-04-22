using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    float frequency = 3f;
    float magnitude = 0.01f;
    private bool used;

    void FixedUpdate() {
        transform.position = transform.position + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
    }

    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Player" && !used) {
            used = true;
            AudioManager.instance.PlaySound(AudioManager.Sound.Coin);
            GameManager.instance.AddRings(1);
            Destroy(gameObject);
        }
    }
}
