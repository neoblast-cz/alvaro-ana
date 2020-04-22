using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCShopKeeper : NPC
{
    [Header("Type")]
    [SerializeField] NPCType IAm;

    [Header("Shopkeeper")]
    [SerializeField] int neededRings;
    public Dialogue shopKeeperEnoughRings;
    public Dialogue shopKeeperNotEnoughRings;

    protected override void InteractionWithPlayer() {
        if (CheckIfEnoughRings())
            DialogueController.instance.StartDialogue(gameObject.name, shopKeeperEnoughRings, transform, false);
        else {
            DialogueController.instance.StartDialogue(gameObject.name, shopKeeperNotEnoughRings, transform, false);
        }
    }

    private bool CheckIfEnoughRings() {
        if (GameManager.instance.score >= neededRings) {
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