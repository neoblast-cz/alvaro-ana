using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

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

    [Header("Music & Sounds")]
    public AudioMixer audioMixer;
    public AudioMixerGroup musicMixerGroup;
    public AudioClip[] gameMusicArray;

    [Header("Sounds")]
    public AudioMixerGroup audioMixerGroup;
    public SoundAudioClip[] soundAudioClipArray;
    [System.Serializable]
    public class SoundAudioClip
    {
        public AudioManager.Sound sound;
        public AudioClip audioClip;
    }

    [Header("Sprites")]
    public Sprite walmortOpened;
}
