using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip _sound1;
    private AudioSource _audioSource;

    public void PlaySound()
    {
        _audioSource.PlayOneShot(_sound1);
    }
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        
    }
}
