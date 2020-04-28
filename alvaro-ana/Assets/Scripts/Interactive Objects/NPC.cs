using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject carryingMemory;

    PlayerInventory playerInventory;

    void Start() {
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Q))
            GiveObject();
    }

    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Player")
            InteractionWithPlayer();
    }

    protected virtual void InteractionWithPlayer()
    {

    }

    public void GiveObject() {
        if (carryingMemory != null){
            playerInventory.GetItem(carryingMemory, false);

            carryingMemory = null;
        }
    }
}