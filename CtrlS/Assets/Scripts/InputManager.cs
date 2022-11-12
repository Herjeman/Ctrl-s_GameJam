using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    private bool _ctrlPressed;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
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
