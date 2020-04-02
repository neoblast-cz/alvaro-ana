using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject carryingMemory;
    private Transform inventory;

    void Start()
    {
        inventory = GameObject.Find("UI_Inventory_DoNotRename").transform;
    }

    void Update()
    {
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

    private void GiveObject()
    {
        if (carryingMemory != null)
        {
            GameObject memoryPF = (GameObject)Instantiate(carryingMemory, inventory.position, Quaternion.identity);
            memoryPF.transform.localScale = new Vector3(1, 1, 1);
            memoryPF.transform.parent = inventory;
        }
    }
}