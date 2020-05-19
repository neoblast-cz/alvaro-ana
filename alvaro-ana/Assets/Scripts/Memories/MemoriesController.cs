using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System.IO;

public class MemoriesController : MonoBehaviour
{
    public static MemoriesController instance;

    PlayerMovement playerMovement;

    [Header("Video")]
    private GameObject video;
    private VideoPlayer videoPlayer;
    public Image playButtonVideo;
    // test
    private string message = " ";
    
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
        audioSource = audio.GetComponent<AudioSource>();
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
    public void StartPlayingVideo(string videoClipName) {
        videoPlayer.url = Path.Combine(Application.streamingAssetsPath, videoClipName);
        videoPlayer.Play();
        
        video.SetActive(true);
        playButtonVideo.sprite = GameAssets.instance.pauseButton;
        
        InitiateMemory(true);
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

    public void CloseVideo() {
        videoPlayer.Pause();
        video.SetActive(false);

        EndMemory(true);
    }

    // photos
    public void ShowPhoto(Sprite newSprite) {
        photoImage.sprite = newSprite;
        photo.SetActive(true);

        InitiateMemory(false);
    }

    public void ClosePhoto() {
        photoImage.sprite = null;
        photo.SetActive(false);

        EndMemory(false);
    }

    public void StartPlayAudio (AudioClip newAudioClip) {
        audio.SetActive(true);
        audioSource.clip = newAudioClip;
        audioSource.outputAudioMixerGroup = GameAssets.instance.audioMixerGroup;
        playButtonAudio.sprite = GameAssets.instance.pauseButton;
        audioSource.Play();
        
        InitiateMemory(true);
    }

    public void PlayPauseAudio() {
        if (audioSource.isPlaying) {
            audioSource.Pause();
            playButtonAudio.sprite = GameAssets.instance.playButton;
        } else {
            audioSource.Play();
            playButtonAudio.sprite = GameAssets.instance.pauseButton;
        }
    }

    public void CloseAudio() {
        audio.SetActive(false);
        audioSource.Pause();

        EndMemory(true);
    }

    private void InitiateMemory(bool audioControl) {
        playerMovement.PlayingMemories();
        CameraController.instance.StartZoomIn(1.5f, 4f);
        UIController.instance.AddBackgroundOverlay();
        UIController.instance.InventorySwitch();
        UIController.instance.HideUI();
        if (audioControl)
            MusicManager.instance.PlayPauseMusic(0.02f);
    }

    private void EndMemory(bool audioControl) {
        CameraController.instance.StartZoomOut(1.5f, 4f);
        UIController.instance.RemoveBackgroundOverlay();
        UIController.instance.ShowUI();
        playerMovement.PlayingMemories();
        if (audioControl)
            MusicManager.instance.PlayPauseMusic(0.3f);
    }
}
