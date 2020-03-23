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
    }
}