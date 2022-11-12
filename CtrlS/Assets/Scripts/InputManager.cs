using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    private bool _ctrlPressed;
    [SerializeField] private PlayerMovement _playerMovement;

    public delegate void InputManagerEvent();
    public static event InputManagerEvent OnSave;
    public static event InputManagerEvent OnLoad;

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

    public void SpaceDown(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _playerMovement.Jump();
        }
    }

    public void MoveAxis(InputAction.CallbackContext context)
    {
        _playerMovement.SetMoveAxis(context.ReadValue<float>());
    }
    
    // public void DDown(InputAction.CallbackContext context)
    // {
    //     if (context.performed)
    //     {
    //         _playerMovement.MoveRight();
    //     }
    // }
    //
    // public void ADown(InputAction.CallbackContext context)
    // {
    //     if (context.performed)
    //     {
    //         _playerMovement.MoveLeft();
    //     }
    // }
}
