using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerKrabice : MonoBehaviour
{
    private float thrust = 800f;
    private Rigidbody2D playerRigidBody;

    void Awake() {
        playerRigidBody = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D target) {
        if (target.gameObject.name == "DashCollider") {
            Debug.Log("hit via dash");
            playerRigidBody.AddForce(transform.up * thrust, ForceMode2D.Impulse);
        }
    }
}
