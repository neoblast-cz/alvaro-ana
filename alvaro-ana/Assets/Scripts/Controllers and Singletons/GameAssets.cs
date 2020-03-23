using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets instance;

    void Awake() {
        if (instance != null) //Singleton Pattern
            Destroy(gameObject);
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    [Header("UI")]
    public GameObject dialoguePf;

    [Header("FX Prefabs")]
    public GameObject bloodPF;

    [Header("Objects")]
    public GameObject mushroomPf;
    public GameObject coinPf;

    [Header("Music")]
    public AudioClip[] gameMusicArray;

    [Header("Sounds")]
    public SoundAudioClip[] soundAudioClipArray;
    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }
}
