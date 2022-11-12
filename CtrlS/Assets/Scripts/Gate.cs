using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private bool _isLocked = true;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        if (!_isLocked)
        {
            _animator.SetTrigger("UnlockGate");
        }
    }

    public void Update()
    {
        _animator.SetTrigger("UnlockGate");
        _isLocked = false;
    }

    public void Cycle()
    {
        if (_isLocked) return;
        _animator.SetTrigger("CycleGate");
    }

    public void Done()
    {
        GameManager.instance.NextLevel();
    }
}
