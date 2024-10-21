using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField]private AudioClip[] bgmClips;
    private AudioSource bgmPlayer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        bgmPlayer = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayBgm(0);
    }

    private void LoadBgmClips()
    {
        bgmClips = Resources.LoadAll<AudioClip>("Bgm");
    }

    public void PlayBgm(int index)
    {
        if (index >= 0 && index < bgmClips.Length)
        {
            bgmPlayer.clip = bgmClips[index];
            bgmPlayer.Play();
        }
        else
        {
            bgmPlayer.Stop();
        }
    }
}