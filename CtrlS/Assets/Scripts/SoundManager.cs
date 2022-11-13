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
    public void PuzzleSolvedSFX()
    {
        _audioSource.PlayOneShot(PuzzleSolved);
    }
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
}
