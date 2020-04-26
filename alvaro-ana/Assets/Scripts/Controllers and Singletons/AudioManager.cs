using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    public enum Sound
    {
        Jump,
        Coin,
        Dying,
        Puff,
        Teleport,
        ShopDoorBell,
        CashRegister,
        Talking,
        UI_Click,
        UI_Error,
        UI_Switch_Click1,
        UI_Switch_Click2,
    }

    void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetMusicVolume(float musicSliderValue) {
        GameAssets.instance.audioMixer.SetFloat("musicVolume", Mathf.Log10(musicSliderValue) * 20);
    }

    public void SetSoundsVolume(float soundsSliderVolume) {
        GameAssets.instance.audioMixer.SetFloat("soundsVolume", Mathf.Log10(soundsSliderVolume) * 20);
    }

    public void PlaySound(Sound sound) {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = GameAssets.instance.audioMixerGroup;
        audioSource.PlayOneShot(GetAudioClip(sound));

        Destroy(soundGameObject, GetAudioClip(sound).length);
    }

    public void PlaySound(Sound sound, float destroyAfter) {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = GameAssets.instance.audioMixerGroup;
        audioSource.PlayOneShot(GetAudioClip(sound));

        Destroy(soundGameObject, destroyAfter);
    }

    private static AudioClip GetAudioClip(Sound sound) {
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.instance.soundAudioClipArray) {
            if (soundAudioClip.sound == sound) {
                return soundAudioClip.audioClip;
            }
        }
        Debug.LogError("Sound " + sound + " not found!");
        return null;
    }
}
