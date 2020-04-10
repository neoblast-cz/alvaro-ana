using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Sprite playButton;
    public Sprite pauseButton;

    [Header("Icons")]
    public Sprite iconVideo;
    public Sprite iconPhoto;
    public Sprite iconAudio;

    [Header("FX Prefabs")]
    public GameObject deathEffectPF;
    public GameObject smokePF;
    public GameObject hitPowPF;
    public GameObject dashPF;
    public GameObject teleportPF;

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
