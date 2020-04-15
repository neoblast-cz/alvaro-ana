using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolmort : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite wolmortClosed;

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        wolmortClosed = spriteRenderer.sprite;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        spriteRenderer.sprite = GameAssets.instance.walmortOpened;
    }

    void OnTriggerExit2D(Collider2D collision) {
        spriteRenderer.sprite = wolmortClosed;
    }
}
