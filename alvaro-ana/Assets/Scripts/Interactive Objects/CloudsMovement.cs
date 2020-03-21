using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsMovement : MonoBehaviour
{
    float minX = -15f;
    float maxX = 256f;
    float speedbase = 0.2f;
    float randomSpeed;

    void Start() {
        randomSpeed = Random.Range(speedbase * 0.2f, speedbase * 2f);
        float randomSize = Random.Range(1f, 1.4f);
        transform.localScale = new Vector3(randomSize, randomSize, randomSize);
    }

    void Update() {
        if (transform.position.x < minX)
            transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
    }

    void FixedUpdate() {
        transform.position = transform.position + Vector3.left * Time.deltaTime * randomSpeed;
    }
}
