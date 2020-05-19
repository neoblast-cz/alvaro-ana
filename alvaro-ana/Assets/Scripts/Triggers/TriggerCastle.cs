using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCastle : MonoBehaviour
{
    public Transform exit;
    private float fxScale = 1f;

    void OnTriggerEnter2D(Collider2D collisionWeTouched) {
        StartCoroutine(GetToTheEnd(collisionWeTouched.gameObject));
    }

    IEnumerator GetToTheEnd(GameObject collisionObject) {
        GameObject teleportEffect = (GameObject)Instantiate(GameAssets.instance.teleportPF, collisionObject.transform.position, collisionObject.transform.rotation);
        teleportEffect.transform.localScale = new Vector3(fxScale, fxScale, fxScale);
        Destroy(teleportEffect, 2f);

        AudioManager.instance.PlaySound(AudioManager.Sound.Teleport);
        GameManager.instance.MovePlayer(exit);

        yield return new WaitForSeconds(0.3f);
    }
}