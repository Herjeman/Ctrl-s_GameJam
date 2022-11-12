using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;

    private bool _ctrlPressed;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public static InputManager GetInstance()
    {
        return _instance; 
    }

    public delegate void InputManagerEvent();
    public static event InputManagerEvent OnSave;
    public static event InputManagerEvent OnLoad;

    public void CtrlPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _ctrlPressed = true;
        }
        else if (context.canceled)
        {
            _ctrlPressed = false;
        }
    }

    public void SDown(InputAction.CallbackContext context)
    {
        if (context.performed && _ctrlPressed)
        {
            OnSave.Invoke();
        }
    }

    public void ZDown(InputAction.CallbackContext context)
    {
        if (context.performed && _ctrlPressed)
        {
            OnLoad.Invoke();
        }
    }
}
