using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    [Header("Type")]
    [SerializeField] NPCType IAm;

    [Header("JustDialogue")]
    public Dialogue justDialogue;

    [Header("Shopkeeper")]
    [SerializeField] int neededRings;
    public Dialogue shopKeeperEnoughRings;
    public Dialogue shopKeeperNotEnoughRings;

    void OnTriggerEnter2D(Collider2D collision) {
        InteractionWithPlayer();
    }

    void InteractionWithPlayer ()
    {
        switch (IAm)
        {
            case (NPCType.JustDialogue):
                DialogueController.instance.StartDialogue(gameObject.name, justDialogue, transform);
                break;
            case (NPCType.Shopkeeper):
                if (CheckIfEnoughRings())
                    DialogueController.instance.StartDialogue(gameObject.name, shopKeeperEnoughRings, transform);
                else
                {
                    DialogueController.instance.StartDialogue(gameObject.name, shopKeeperNotEnoughRings, transform);
                }
                break;
            default:
                break;
        }
    }

    private bool CheckIfEnoughRings()
    {
        if (GameManager.instance.score >= neededRings)
        {
            return true;
        }
        else return false;
    }
}



public enum NPCType
{
    JustDialogue,
    Shopkeeper,
}