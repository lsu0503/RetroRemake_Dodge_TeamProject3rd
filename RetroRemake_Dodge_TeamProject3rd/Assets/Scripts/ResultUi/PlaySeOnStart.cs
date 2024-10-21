using UnityEngine;

public class PlaySeOnStart : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        audioSource.PlayOneShot(audioClip);
    }
}