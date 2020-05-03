using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class Memory : MonoBehaviour
{
    [Header("Type")]
    public MemoryType memoryType;

    private Image[] icons;
    private Image icon;
    public TMP_Text nameText;

    public string videoName;
    public Sprite photo;
    public AudioClip audioClip;

    public void OnEnable() {
        nameText = GetComponentInChildren<TMP_Text>();
        icons = GetComponentsInChildren<Image>();
        for (int i = 0; i < icons.Length; i++) {
            if (icons[i].name == "Icon")
                icon = icons[i];
        }
        //gameObject.name.Replace("(Clone)", "");
        

        switch (memoryType)
        {
            case (MemoryType.Video):
                icon.sprite = GameAssets.instance.iconVideo;
                break;
            case (MemoryType.Audio):
                icon.sprite = GameAssets.instance.iconAudio;
                break;
            case (MemoryType.Photo):
                icon.sprite = GameAssets.instance.iconPhoto;
                break;
            default:
                break;
        }
    }

    public void Update()
    {
        if (nameText.text != gameObject.name)
            nameText.text = gameObject.name.ToString();
    }

    public void PlayMemory() {
        switch (memoryType)
        {
            case (MemoryType.Video):
                MemoriesController.instance.StartPlayingVideo(videoName);
                break;
            case (MemoryType.Audio):
                MemoriesController.instance.StartPlayAudio(audioClip);
                break;
            case (MemoryType.Photo):
                MemoriesController.instance.ShowPhoto(photo);
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
    Photo
}