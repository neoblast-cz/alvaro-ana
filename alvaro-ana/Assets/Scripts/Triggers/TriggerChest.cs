using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChest : MonoBehaviour
{
    private bool used;
    private SpriteRenderer spriteRenderer;
    private float finalTransparency = 0.8f;
    private float powScale = 1.5f;
    private Vector3 offset = new Vector3(0f, 0.5f, 0f);

    void Start() {
        spriteRenderer = GetComponent < SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D target) {
        if (!used) {
            used = true;
            Instantiate(GameAssets.instance.coinPf, transform.position + offset, Quaternion.identity);

            GameObject pow = Instantiate(GameAssets.instance.hitPowPF, transform.position, Quaternion.identity);
            pow.transform.localScale = new Vector3(powScale, powScale, powScale);
            Destroy(pow, 2f);

            spriteRenderer.color = new Vector4(1f, 1f, 1f, finalTransparency);
        }
    }
}