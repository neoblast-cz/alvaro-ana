﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    float frequency = 2f;
    float magnitude = 0.01f;
    private bool used;
    private CircleCollider2D collider;

    void Start()
    {
        collider = GetComponentInChildren<CircleCollider2D>();
        collider.enabled = false;
        StartCoroutine(ActivateCollider());
    }

    void FixedUpdate() {
        transform.position = transform.position + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
    }

    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Player" && !used) {
            used = true;
            AudioManager.instance.PlaySound(AudioManager.Sound.Coin);

            GameObject particle = (GameObject)Instantiate(GameAssets.instance.coinEffectPF, transform.position, transform.rotation);
            particle.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            Destroy(particle, 2f);

            GameManager.instance.AddRings(1);
            Destroy(gameObject);
        }
    }

    IEnumerator ActivateCollider() {
        yield return new WaitForSeconds(1f);
        collider.enabled = true;
    }
}
