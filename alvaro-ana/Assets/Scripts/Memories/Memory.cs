using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Audio;

public class Memory : MonoBehaviour
{

    public MemoryType memoryType;
    private  VideoController videoController;
    public VideoClip videoclip;
    public AudioClip audioClip;

    public void Awake() {
        videoController = GameObject.Find("VideoController_DoNotRename").GetComponent<VideoController>();
    }

    public void PlayMemory() {
        switch (memoryType)
        {
            case (MemoryType.Video):
                videoController.StartPlayingVideo(videoclip);
                break;
            case (MemoryType.Audio):
                break;
            case (MemoryType.Image):
                break;
            default:
                break;
        }
    }
}

public enum MemoryType
{
    Video,
    Audio,
    Image
}