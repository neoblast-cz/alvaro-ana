using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerConfetti : MonoBehaviour
{
    ParticleSystem confetti;

    void Start() {
        confetti = GetComponent<ParticleSystem>();
        confetti.Stop();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("entered");
        confetti.Play();
    }

    void OnTriggerExit2D(Collider2D collision) {
        confetti.Stop();
    }
}
