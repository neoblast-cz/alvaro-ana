using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCJustDialogue : NPC
{
    public Dialogue justDialogue;

    protected override void InteractionWithPlayer () {
        DialogueController.instance.StartDialogue(gameObject.name, justDialogue, transform, false);
    }
}