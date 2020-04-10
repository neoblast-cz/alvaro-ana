using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPipeEntrance : MonoBehaviour
{
    public Transform exit;
    private float fxScale = 1f;
    private bool used;

    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Player" && !used) {
            Move();
            used = true;
        }
    }

    private void Move() {
        GameObject teleportEffect = (GameObject)Instantiate(GameAssets.instance.teleportPF, transform.position, transform.rotation);
        teleportEffect.transform.localScale = new Vector3(fxScale, fxScale, fxScale);
        Destroy(teleportEffect, 2f);

        GameManager.instance.MovePlayer(exit);
	}
    
}