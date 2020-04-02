using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoController : MonoBehaviour
{

    private VideoPlayer videoPlayer;
    private GameObject video;
    public Image playButton;

    void Awake() {
        video = GameObject.Find("Video_DoNotRename");
        videoPlayer = video.GetComponent<VideoPlayer>();
        videoPlayer.Pause();
        video.SetActive(false);
    }

    public void StartPlayingVideo(VideoClip videoClip)
    {
        videoPlayer.clip = videoClip;
        video.SetActive(true);
        playButton.sprite = GameAssets.instance.pauseButton;
        MusicManager.instance.PlayPause();
        InventoryController.instance.InventorySwitch();
    }

    public void ClosePlayer()
    {
        videoPlayer.Pause();
        InventoryController.instance.InventorySwitch();
        MusicManager.instance.PlayPause();
    }

    public void PlayPauseVideo()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
            playButton.sprite = GameAssets.instance.playButton;
        }
        else
        {
            videoPlayer.Play();
            playButton.sprite = GameAssets.instance.pauseButton;
        }
    }
}
