﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetPandaMovement : MonoBehaviour
{
    private float speed = 1f;
    private float distance = 1f;

    private bool movingRight = true;
    public Transform groundDetection;

    void Start() {
        Transform[] allTransforms = GetComponentsInChildren<Transform>();
        groundDetection = allTransforms[1];
    }

    void Update() {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false) {
            if (movingRight == true) {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            } else {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        } // update
    }
}