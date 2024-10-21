using System;
using UnityEngine;

public class SEContainer : MonoBehaviour
{
    [SerializeField] private AudioClip deathClip;
    private AudioSource audioSource;
    private CharacterBehavior behavior;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        behavior = GetComponent<CharacterBehavior>();
    }

    private void Start()
    {
        behavior.OnDieEvent += PlayDeathSound;
    }

    private void PlayDeathSound()
    {
        audioSource.PlayOneShot(deathClip);
    }
}