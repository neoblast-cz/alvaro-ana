using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemyKill : MonoBehaviour
{
    private GameObject mainPanda;
    public TriggerDeadWithBlood killTrigger;
    private Animator animator;
    private float thrust = 10f;

    void Awake() {
        mainPanda = gameObject.transform.parent.gameObject;
        killTrigger = mainPanda.GetComponentInChildren<TriggerDeadWithBlood>();
        animator = mainPanda.GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D target) {
        if (target.gameObject.tag == "Player")
        {
            animator.SetTrigger("StreetPandaDie");
            killTrigger.enabled = false;

            target.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * thrust, ForceMode2D.Impulse);
            //target.gameObject.GetComponent<CharacterController2D>().Move(0f, false, true);

            Destroy(mainPanda, 1f);
        }
    }
}