using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance { get; private set; }

    AudioSource musicSource;
    public List<AudioClip> list;
    private float originalVolume;

    void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start() {
        musicSource = GetComponent<AudioSource>();
        originalVolume = musicSource.volume;
    }

    void Update() {
        if (!musicSource.isPlaying) {
            list.Remove(musicSource.clip);
            musicSource.clip = GetRandomClip();
            musicSource.Play();

            Debug.Log("new clips started, should take:" + musicSource.clip.length + "seconds");
            Debug.Log("new clips name: " + musicSource.clip.name);
        }
    }

    private AudioClip GetRandomClip() {
        if (list.Count == 0) {
            AddTracks();
        }

        return list[Random.Range(0, list.Count)];
    }

    void AddTracks() {
        list = new List<AudioClip>();
        foreach (AudioClip musicClip in GameAssets.instance.gameMusicArray) {
            list.Add(musicClip);
        }
    }

    public void PlayPauseMusic(float newValue) {
        musicSource.volume = newValue;
    }
}