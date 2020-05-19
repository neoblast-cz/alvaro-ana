using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableMemory : Interactable
{
    private float fxScale = 1f;

    protected override void InteractionWithPlayer() {
        GiveObject();

        GameObject coinEffect = (GameObject)Instantiate(GameAssets.instance.coinEffectPF, transform.position, transform.rotation);
        coinEffect.transform.localScale = new Vector3(fxScale, fxScale, fxScale);
        Destroy(coinEffect, 2f);


        Destroy(gameObject);
    }
}
