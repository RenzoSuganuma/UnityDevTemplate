using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnPlayerInput : MonoBehaviour, InputSystemActions.IPlayerActions
{
    public static EnPlayerInput Instance { get; private set; }

    #region InputValues

    public Vector2 MoveInput { get; private set; }

    #endregion

    private InputSystemActions _input;

    private void Awake()
    {
        _input = new();
        _input.Enable();
        _input.Player.AddCallbacks(this);
    }

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void OnDisable()
    {
        _input.Player.RemoveCallbacks(this);
        _input.Disable();
    }

    private void OnDestroy()
    {
        _input.Dispose();
        _input = null;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            MoveInput = context.ReadValue<Vector2>();
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
    }

    public void OnJump(InputAction.CallbackContext context)
    {
    }

    public void OnPrevious(InputAction.CallbackContext context)
    {
    }

    public void OnNext(InputAction.CallbackContext context)
    {
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
    }
}