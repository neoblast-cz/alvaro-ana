using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    GameObject player;
    private float fxScale = 1f;

    public int score;

    void Start() {
        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        player = GameObject.FindGameObjectWithTag("Player");

        score = 0;
    }

    public void RestartLevel(float delay) {
        player.SetActive(false);
        StartCoroutine(RestartLevelCoroutine(delay));
    }

    public void AddRings(int addition) {
        score = score + addition;
        UIController.instance.UpdateRingsScore(score);
    }

    IEnumerator RestartLevelCoroutine (float delay) {
        yield return new WaitForSeconds(delay);
        CameraController.instance.RestartCamera();
        player.transform.position = Vector3.zero;
        player.SetActive(true);
        GameObject puff = (GameObject)Instantiate(GameAssets.instance.smokePF, transform.position, transform.rotation);
        puff.transform.localScale = new Vector3(2f, 2f, 2f);
        Destroy(puff, 2f);
    }

    public void MovePlayer (Transform finalDestination)
    {
        player.SetActive(false);
        StartCoroutine(MovePlayerCoroutine(finalDestination));
    }

    IEnumerator MovePlayerCoroutine (Transform finalDestination)
    {
        yield return new WaitForSeconds(1f);
        CameraController.instance.RestartCamera();
        player.transform.position = finalDestination.position;

        GameObject teleportEffect = (GameObject)Instantiate(GameAssets.instance.teleportPF, transform.position, transform.rotation);
        teleportEffect.transform.localScale = new Vector3(fxScale, fxScale, fxScale);
        Destroy(teleportEffect, 2f);

        player.SetActive(true);
    }
}