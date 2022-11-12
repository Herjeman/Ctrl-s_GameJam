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
            Debug.Log("Ctrl was pressed");
            _ctrlPressed = true;
        }
        else if (context.canceled)
        {
            Debug.Log("Ctrl was released");
            _ctrlPressed = false;
        }
    }
}
