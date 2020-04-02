using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance { get; private set; }

    AudioSource musicSource;
    List<AudioClip> list;
    public float standardVolume = 0.33f;
    public float pitch = 1.1f;
    public float transitionTime = 10f;

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
        musicSource.pitch = pitch;
        musicSource.volume = standardVolume;
        // create list and add clips from game assets
        list = new List<AudioClip>();
        foreach (AudioClip musicClip in GameAssets.instance.gameMusicArray)
        {
            list.Add(musicClip);
        }

        StartCoroutine(PlayRandomMusic());
    }

    IEnumerator PlayRandomMusic() {
        int randomNumber = Random.Range(0, list.Count);

        musicSource.clip = list[randomNumber];
        musicSource.Play();

        yield return new WaitForSeconds(list[randomNumber].length);

        StartCoroutine(PlayRandomMusic());
    }

    public void PlayPause() {
        if (musicSource.isPlaying) {
            musicSource.Pause();
        }
        else {
            musicSource.Play();
        }
    }
}
