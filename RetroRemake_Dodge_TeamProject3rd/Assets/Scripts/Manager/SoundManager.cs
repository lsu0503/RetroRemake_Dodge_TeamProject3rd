using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("#BGM")]
    public AudioClip bgmClip;
    public float bgmVolume;
    public Slider bgmVolumeSlider;
    AudioSource bgmPlayer;

    [Header("#SFX")]
    public AudioClip[] sfxClips;
    public float sfxVolume;
    public int channels;
    AudioSource[] sfxPlayers;
    int channelIndex;
    public Slider SfxVolumeSlider;

    private void Awake()
    {
        instance = this;
        Init();
    }

    private void Start()
    {
        PlayBgm(true);
        bgmVolumeSlider.value = bgmVolume;
        bgmVolumeSlider.onValueChanged.AddListener(OnBgmVolumeSliderChanged);
    }

    void Init() 
    {
        GameObject bgmObject = new GameObject("BgmPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayer = bgmObject.AddComponent<AudioSource>();
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;
        bgmPlayer.clip = bgmClip;

        GameObject sfxObject = new GameObject("SfxPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels];

        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            sfxPlayers[index] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[index].playOnAwake = false;
            sfxPlayers[index].volume = sfxVolume;
        }

    }

    public void PlayBgm(bool isPlay) 
    
    {
        if (isPlay) 
        {
            bgmPlayer.Play();
        }
        else
        {
            bgmPlayer.Stop();
        }

    }
    public void OnBgmVolumeSliderChanged(float value)
    {
        bgmPlayer.volume = value;
        bgmVolume = value; 
    }

}