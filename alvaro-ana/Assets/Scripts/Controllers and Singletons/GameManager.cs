using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    GameObject player;
    private float fxScale = 1f;

    private int totalNumberOfRings;
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
        
        GameAssets.instance.pauseMenu.SetActive(false);

        SpriteRenderer[] rings = GameObject.Find("_Rings_DoNotRename").GetComponentsInChildren<SpriteRenderer>();
        totalNumberOfRings = rings.Length;
        score = 0;
        UIController.instance.UpdateRingsScore(score, totalNumberOfRings);
    }

    public void RestartLevel(float delay) {
        player.SetActive(false);
        StartCoroutine(RestartLevelCoroutine(delay));
    }

    public void AddCoins(int addition) {
        score = score + addition;
        UIController.instance.UpdateRingsScore(score, totalNumberOfRings);
    }

    public void RemoveCoins(int subtraction) {
        score = score - subtraction;
        UIController.instance.UpdateRingsScore(score, totalNumberOfRings);
    }

    public int ReturnNumberOfRings() {
        return score;
    }

    IEnumerator RestartLevelCoroutine (float delay) {
        yield return new WaitForSeconds(delay);
        CameraController.instance.RestartCamera();
        player.transform.position = Vector3.zero;
        player.SetActive(true);
        GameObject puff = (GameObject)Instantiate(GameAssets.instance.smokePF, transform.position, transform.rotation);
        puff.transform.localScale = new Vector3(2f, 2f, 2f);
        Destroy(puff, 2f);
        AudioManager.instance.PlaySound(AudioManager.Sound.Puff);
    }

    public void MovePlayer (Transform finalDestination) {
        StartCoroutine(MovePlayerCoroutine(finalDestination));
    }

    IEnumerator MovePlayerCoroutine (Transform finalDestination) {
        yield return new WaitForSeconds(0.5f);
        player.SetActive(false);

        CameraController.instance.RestartCamera();
        player.transform.position = finalDestination.position;

        GameObject teleportEffect = (GameObject)Instantiate(GameAssets.instance.teleportPF, transform.position, transform.rotation);
        teleportEffect.transform.localScale = new Vector3(fxScale, fxScale, fxScale);
        Destroy(teleportEffect, 2f);

        player.SetActive(true);
    }

    public void QuitTheGame() {
        AudioManager.instance.PlaySound(AudioManager.Sound.UI_Switch_Click2);
        Debug.Log("quitting");
        Application.Quit();
    }

    public void RestartScene() {
        AudioManager.instance.PlaySound(AudioManager.Sound.UI_Switch_Click2);
        Debug.Log("restarting");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}