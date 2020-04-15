using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance { get; private set; }

    AudioSource musicSource;
    List<AudioClip> list;

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

        list = new List<AudioClip>();
        foreach (AudioClip musicClip in GameAssets.instance.gameMusicArray) {
            list.Add(musicClip);
        }
        
        StartCoroutine(PlayRandomMusic());
    }

    IEnumerator PlayRandomMusic() {
        //choose random number
        int randomNumber = Random.Range(0, list.Count);

        // play music clip based on random number
        musicSource.clip = list[randomNumber];
        musicSource.Play();

        yield return new WaitForSeconds(list[randomNumber].length);
        //let's start again
        StartCoroutine(PlayRandomMusic());
    }

    public void PlayPauseMusic() {
        if (musicSource.isPlaying) {
            musicSource.Pause();
        }
        else {
            musicSource.Play();
        }
    }
}
