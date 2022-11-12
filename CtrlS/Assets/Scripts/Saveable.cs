using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Saveable : MonoBehaviour
{
    private Vector3 _savedPosition;
    private Quaternion _savedRotation;
    private bool _savedKinematicState;
    private Rigidbody _rb;

    private void Awake()
    {
        InputManager.OnSave += SaveTransform;
        InputManager.OnLoad += LoadTransform;

        _rb = GetComponent<Rigidbody>();
        _savedPosition = transform.position;
        _savedKinematicState = _rb.isKinematic;
    }

    private void SaveTransform()
    {
        _savedPosition = this.transform.position;
        _savedRotation = this.transform.rotation;
        _savedKinematicState = _rb.isKinematic;
        Debug.Log("Saved a piece of the world at: " + _savedPosition);
    }

    private void LoadTransform()
    {
        this.transform.position = _savedPosition;
        this.transform.rotation = _savedRotation;
        _rb.isKinematic = _savedKinematicState;
        Debug.Log("Restored a piece of the world to: " + _savedPosition);
    }

    private void OnDestroy()
    {
        InputManager.OnSave -= SaveTransform;
        InputManager.OnLoad -= LoadTransform;
    }
}
