using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private GameObject player;
    private Vector3 theScale;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        theScale = transform.localScale;
    }

    private void Update() {
        if (transform.position.x > player.transform.position.x) {
            theScale.x = +1;
            
        } else {
            theScale.x = -1;
        }
        transform.localScale = theScale;
    }
}
