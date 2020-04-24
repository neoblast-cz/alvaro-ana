using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    GameObject player;
    private float fxScale = 1f;

    public bool pauseScreenActive;

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

    public void AddRings(int addition) {
        score = score + addition;
        UIController.instance.UpdateRingsScore(score, totalNumberOfRings);
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
        player.GetComponent<Animator>().SetTrigger("warpIn");
        yield return new WaitForSeconds(0.5f);
        player.SetActive(false);

        CameraController.instance.RestartCamera();
        player.transform.position = finalDestination.position;

        GameObject teleportEffect = (GameObject)Instantiate(GameAssets.instance.teleportPF, transform.position, transform.rotation);
        teleportEffect.transform.localScale = new Vector3(fxScale, fxScale, fxScale);
        Destroy(teleportEffect, 2f);

        player.SetActive(true);
        player.GetComponent<Animator>().SetTrigger("warpOut");
    }

    public void PauseScreenToggle() {
        if (pauseScreenActive) {
            GameAssets.instance.pauseMenu.SetActive(false);
            CameraController.instance.StartZoomOut(2.5f, 4f);
            UIController.instance.RemoveBackgroundOverlay();
            pauseScreenActive = !pauseScreenActive;
        } else {
            GameAssets.instance.pauseMenu.SetActive(true);
            CameraController.instance.StartZoomIn(2.5f, 4f);
            UIController.instance.AddBackgroundOverlay();
            pauseScreenActive = !pauseScreenActive;
        }
    }

    public void QuitTheGame() {
        Debug.Log("quitting");
        Application.Quit();
    }

    public void RestartScene() {
        Debug.Log("restarting");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}