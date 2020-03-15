using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    bool goingRight = true;
    float speed = 2f;

    RaycastHit2D hit;

    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Player") {
            KillMe();
        }
    }

    public void Update() {
        if (transform.position.y < -20f) {
            KillMe();
        }

        if (goingRight) {
            hit = Physics2D.Raycast(transform.position + new Vector3(0.5f, 0f, 0f), Vector3.right);
        }
        else {
            hit = Physics2D.Raycast(transform.position + new Vector3(-0.5f, 0f, 0f), Vector3.left);
        }
        if (hit.distance <= 0.05f) {
            goingRight = !goingRight;
            Debug.Log(hit.collider.gameObject.name);
        }
    }

    public void FixedUpdate() {
        
        if (goingRight) {
            transform.position = transform.position + Vector3.right * speed * Time.deltaTime;
        }
        else {
            transform.position = transform.position + Vector3.left * speed * Time.deltaTime;
        }
    }


    private void KillMe() {
        Destroy(gameObject);
    }
}