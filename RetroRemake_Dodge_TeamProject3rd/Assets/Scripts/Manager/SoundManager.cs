using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField]private List<AudioClip> bgmClips;
    [SerializeField] private float bgmVolume;
    [SerializeField] private Slider bgmVolumeSlider;
    AudioSource bgmPlayer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
            BackgroundMusic();
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayBgm(0);
        bgmVolumeSlider.value = bgmVolume;
        bgmVolumeSlider.onValueChanged.AddListener(BgmVolumeSlider);
    }

    private void BackgroundMusic()
    {
        GameObject bgmObject = new GameObject("BgmPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayer = bgmObject.AddComponent<AudioSource>();
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;
    }

    public void PlayBgm(int index)
    {
        if (index >= 0 && index < bgmClips.Count)
        {
            bgmPlayer.clip = bgmClips[index];
            bgmPlayer.Play();
        }
        else
        {
            bgmPlayer.Stop();
        }
    }

    public void BgmVolumeSlider(float value)
    {
        bgmPlayer.volume = value;
        bgmVolume = value;
    }
}