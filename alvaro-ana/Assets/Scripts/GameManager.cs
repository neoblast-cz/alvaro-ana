using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    GameObject virtualCamera;
    GameObject player;
    Vector3 startPosition;
    Quaternion startRotation;

    int score;

    void Start() {
        if (instance != null){
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        player = GameObject.FindGameObjectWithTag("Player");

        score = 0;

        virtualCamera = GameObject.Find("MainVirtualCamera");
        startPosition = virtualCamera.transform.position;
        startRotation = virtualCamera.transform.rotation;
    }

    public void RestartLevel() {
        virtualCamera.SetActive(false);
        virtualCamera.transform.SetPositionAndRotation(startPosition, startRotation);
        virtualCamera.SetActive(true);
        player.transform.position = Vector3.zero;
    }

    public void AddScore(int addition)
    {
        score = score + addition;
        Debug.Log(score);
    }
}
