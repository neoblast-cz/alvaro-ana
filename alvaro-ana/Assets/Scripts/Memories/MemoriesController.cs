using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class MemoriesController : MonoBehaviour
{
    public static MemoriesController instance;

    PlayerMovement playerMovement;

    [Header("Video")]
    private VideoPlayer videoPlayer;
    private GameObject video;
    public Image playButtonVideo;

    [Header("Photo")]
    private GameObject photo;
    private Image photoImage;

    [Header("Audio")]
    private GameObject audio;
    private AudioSource audioSource;
    public Image playButtonAudio;

    void Awake() {
        video = GameObject.Find("Video_DoNotRename");
        videoPlayer = video.GetComponent<VideoPlayer>();
        playerMovement = FindObjectOfType<PlayerMovement>();

        photo = GameObject.Find("Photo_DoNotRename");
        photoImage = photo.GetComponent<Image>();
        photo.SetActive(false);
        photoImage.color = new Vector4(1, 1, 1, 1);

        audio = GameObject.Find("Audio_DoNotRename");
        audio.SetActive(false);
    }

    void Start(){
        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        videoPlayer.Pause();
        video.SetActive(false);
    }


    // videos
    public void StartPlayingVideo(VideoClip videoClip) {
        videoPlayer.clip = videoClip;
        video.SetActive(true);
        playButtonVideo.sprite = GameAssets.instance.pauseButton;
        MusicManager.instance.PlayPause();
        UIController.instance.InventorySwitch();
        playerMovement.PlayingMemories();
    }

    public void ClosePlayer() {
        videoPlayer.Pause();
        video.SetActive(false);
        MusicManager.instance.PlayPause();
        playerMovement.PlayingMemories();
    }

    public void PlayPauseVideo() {
        if (videoPlayer.isPlaying) {
            videoPlayer.Pause();
            playButtonVideo.sprite = GameAssets.instance.playButton;
        }
        else {
            videoPlayer.Play();
            playButtonVideo.sprite = GameAssets.instance.pauseButton;
        }
    }

    // photos
    public void ShowPhoto(Image newSprite) {
        photoImage = newSprite;
        photo.SetActive(true);
        UIController.instance.InventorySwitch();
        playerMovement.PlayingMemories();
    }

    public void ClosePhoto() {
        photoImage.sprite = null;
        photo.SetActive(false);
        playerMovement.PlayingMemories();
    }

    public void StartPlayAudio (AudioClip newAudioClip) {
        audio.SetActive(true);
        audioSource.clip = newAudioClip;
        playButtonAudio.sprite = GameAssets.instance.pauseButton;
        audioSource.Play();
        playerMovement.PlayingMemories();
    }

    public void PlayPauseAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
            playButtonAudio.sprite = GameAssets.instance.playButton;
        } else
        {
            audioSource.Play();
            playButtonAudio.sprite = GameAssets.instance.pauseButton;
        }
    }

    public void CloseAudio()
    {
        audio.SetActive(false);
        audioSource.Pause();
        playerMovement.PlayingMemories();
    }
}
