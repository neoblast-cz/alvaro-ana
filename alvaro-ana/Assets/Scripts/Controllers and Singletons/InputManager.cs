using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            pauseMenu.SetActive(!pauseMenu.active);
            AudioManager.instance.PlaySound(AudioManager.Sound.UI_Switch_Click1);
        }
    }
}