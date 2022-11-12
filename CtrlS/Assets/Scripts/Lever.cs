using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private Gate _gate;

    private void Awake()
    {
        _animator= GetComponent<Animator>();
    }

    public void Switch()
    {
        _animator.SetTrigger("Switch");
        _gate.Unlock();
    }
}
