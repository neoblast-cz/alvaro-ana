using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    GameObject player;

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

    public void RestartLevel() {
        StartCoroutine(RestartLevelCoroutine());
    }

    public void AddRings(int addition) {
        score = score + addition;
        UIController.instance.UpdateRingsScore(score);
    }

    IEnumerator RestartLevelCoroutine () {
        yield return new WaitForSeconds(0.2f);
        CameraController.instance.RestartCamera();
        player.transform.position = Vector3.zero;
    }
}