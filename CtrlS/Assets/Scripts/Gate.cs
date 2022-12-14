using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private SoundManager _sm;
    public bool _isLocked;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        if (!_isLocked)
        {
            _animator.SetTrigger("UnlockGate");
        }
    }

    public void Unlock()
    {
        _sm.PuzzleSolvedSFX();
        _animator.SetTrigger("UnlockGate");
        _isLocked = false;
    }

    public void Cycle()
    {
        if (_isLocked) return;
        _sm.TeleportSFX();
        _animator.SetTrigger("CycleGate");
    }

    public void Done()
    {
        GameManager.instance.NextLevel();
    }
}
