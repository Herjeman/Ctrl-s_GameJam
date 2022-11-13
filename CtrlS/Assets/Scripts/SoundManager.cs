using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip Jump;
    [SerializeField] private AudioClip PuzzleSolved;
    private AudioSource _audioSource;

    public void JumpSFX()
    {
        _audioSource.PlayOneShot(Jump);
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
}
