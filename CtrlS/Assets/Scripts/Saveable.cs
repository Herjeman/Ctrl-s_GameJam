using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Saveable : MonoBehaviour
{
    private Transform _savedTransform;

    private void Awake()
    {
        InputManager.OnSave += SaveTransform;
        InputManager.OnLoad += LoadTransform;
    }

    private void SaveTransform()
    {
        _savedTransform = this.transform;
        Debug.Log("Saved a piece of the world at: " + _savedTransform.position);
    }

    private void LoadTransform()
    {
        this.transform.position = _savedTransform.position;
        this.transform.rotation = _savedTransform.rotation;
        this.transform.localScale = _savedTransform.localScale;
        Debug.Log("Restored the world");
    }

    private void OnDestroy()
    {
        InputManager.OnSave -= SaveTransform;
        InputManager.OnLoad -= LoadTransform;
    }
}
