using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject carryingMemory;

    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Player")
            InteractionWithPlayer();
    }

    protected virtual void InteractionWithPlayer()
    {

    }

    public void GiveObject() {
        if (carryingMemory != null){
            PlayerInventory.instance.GetItem(carryingMemory, false);


            carryingMemory = null;
        }
    }
}