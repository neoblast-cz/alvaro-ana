using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance { get; private set; }

    AudioSource musicSource;
    public List<AudioClip> list;

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
        StartCoroutine(PlayRandomMusic());
    }

    IEnumerator PlayRandomMusic() {
        //load track
        if (list.Count == 0) {
            AddTracks();
        }

        //choose random number
        int randomNumber = Random.Range(0, list.Count);

        // play music clip based on random number
        musicSource.clip = list[randomNumber];
        musicSource.Play();

        Debug.Log("new clips started, should take:" + musicSource.clip.length + "seconds");
        Debug.Log("new clips name: " + musicSource.clip.name);

        list.Remove(list[randomNumber]);
        yield return new WaitForSeconds(musicSource.clip.length);

        //finished? let's start again
        NextRandomTrack();
    }

    void AddTracks() {
        list = new List<AudioClip>();
        foreach (AudioClip musicClip in GameAssets.instance.gameMusicArray) {
            list.Add(musicClip);
        }
    }

    public void PlayPauseMusic() {
        if (musicSource.isPlaying) {
            musicSource.Pause();
        }
        else {
            musicSource.Play();
        }
    }

    //public void ChangeTrack(AudioClip newClip) {
    //    musicSource.clip = newClip;
    //    musicSource.Play();
    //}

    public void NextRandomTrack() {
        StopCoroutine(PlayRandomMusic());
        Debug.Log("stop coroutine");
        StartCoroutine(PlayRandomMusic());
    }
}