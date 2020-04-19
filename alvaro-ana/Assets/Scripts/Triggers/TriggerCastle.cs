using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCastle : MonoBehaviour
{
    public Transform exit;
    private float fxScale = 1f;
    private GameObject player;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D collision) {
        Move();
    }

    private void Move() {
        GameObject teleportEffect = (GameObject)Instantiate(GameAssets.instance.teleportPF, player.transform.position, player.transform.rotation);
        teleportEffect.transform.localScale = new Vector3(fxScale, fxScale, fxScale);
        Destroy(teleportEffect, 2f);

        StartCoroutine(ChangeSkinAndFun());
        GameManager.instance.MovePlayer(exit);
    }

    IEnumerator ChangeSkinAndFun()
    {
        yield return new WaitForSeconds(0.5f);
        player.GetComponent<PlayerMovement>().CannotJump();
        player.GetComponentInChildren<SpriteRenderer>().sprite = GameAssets.instance.groomSkin;

        yield return new WaitForSeconds(0.5f);
        CameraController.instance.StartZoomIn(3f, 4f);
    }

}
