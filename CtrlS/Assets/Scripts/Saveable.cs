using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class Saveable : MonoBehaviour
{
    private Vector3 _savedPosition;

    private void Awake()
    {
        InputManager.OnSave += SaveTransform;
        InputManager.OnLoad += LoadTransform;

        _savedPosition = transform.position;
    }

    private void SaveTransform()
    {
        _savedPosition = this.transform.position;
        Debug.Log("Saved a piece of the world at: " + _savedPosition);
    }

    private void LoadTransform()
    {
        if (_savedPosition == null)
        {
            return;
        }
        this.transform.position = _savedPosition;
        Debug.Log("Restored a piece of the world to: " + _savedPosition);
    }

    private void OnDestroy()
    {
        InputManager.OnSave -= SaveTransform;
        InputManager.OnLoad -= LoadTransform;
    }
}
