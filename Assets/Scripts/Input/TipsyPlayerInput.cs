using System;
using R3;
using UnityEngine;
using UnityEngine.InputSystem;

public class TipsyPlayerInput : MonoBehaviour, InputSystemActions.IPlayerActions
{
    public static TipsyPlayerInput Instance { get; private set; }

    #region InputValues

    public Vector2 MoveInput { get; private set; }
    public Vector2 LookInput { get; private set; }
    public Subject<Unit> OnAttackFired { get; private set; } = new();
    public Subject<Unit> OnInteractFired { get; private set; } = new();
    public Subject<Unit> OnCrouchFired { get; private set; } = new();
    public Subject<Unit> OnJumpFired { get; private set; } = new();
    public Subject<Unit> OnSprintFired { get; private set; } = new();

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
        if (context.action.name is "Move")
        {
            MoveInput = context.ReadValue<Vector2>();
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        if (context.action.name is "Look")
        {
            LookInput = context.ReadValue<Vector2>();
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.action.name is "Attack" && context.performed)
        {
            OnAttackFired.OnNext(Unit.Default);
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.action.name is "Interact" && context.performed)
        {
            OnInteractFired.OnNext(Unit.Default);
        }
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.action.name is "Crouch" && context.performed)
        {
            OnCrouchFired.OnNext(Unit.Default);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.action.name is "Jump" && context.performed)
        {
            OnJumpFired.OnNext(Unit.Default);
        }
    }

    public void OnPrevious(InputAction.CallbackContext context)
    {
    }

    public void OnNext(InputAction.CallbackContext context)
    {
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.action.name is "Sprint" && context.performed)
        {
            OnSprintFired.OnNext(Unit.Default);
        }
    }
}