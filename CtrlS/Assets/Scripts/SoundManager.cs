using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip _jump;
    [SerializeField] private AudioClip _puzzleSolved;
    [SerializeField] private AudioClip _ctrlS;
    [SerializeField] private AudioClip _ctrlZ;
    [SerializeField] private AudioClip _teleport;
    private AudioSource _audioSource;

    
    public void JumpSFX()
    {
        _audioSource.PlayOneShot(_jump);
    }

        public void PuzzleSolvedSFX()
    {
        _audioSource.PlayOneShot(_puzzleSolved);
    }

        public void CtrlSSFX()
    {
        _audioSource.PlayOneShot(_ctrlS);
    }

       public void CtrlZSFX()
    {        
        _audioSource.PlayOneShot(_ctrlZ);
    }

       public void TeleportSFX()
    {
        _audioSource.PlayOneShot(_teleport);
    }
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
}
