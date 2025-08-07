using ImTipsyDude.InstantCS;
using R3;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder((int)ExecutionOrder.Scene)]
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

    /// <summary> ドラッグの向きをベクトルとしてパラメータに渡す </summary>
    private Subject<Vector2> _onStartDrag = new();

    public Observable<Vector2> OnStartDrag => _onStartDrag;
    private Subject<Vector2> _onEndDrag = new();
    public Observable<Vector2> OnEndDrag => _onEndDrag;

    #endregion

    public Vector2 FirstScreenPosOnDrag { get; private set; } = Vector2.zero;

    private InputSystemActions _input;
    private bool _mouseClicked = false;
    private bool _dragging = false;

    private ICSWorld _world;

    private Vector2 _screenCenter;

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

        _world = ICSWorld.Instance;

        var h = Screen.currentResolution.height;
        var w = Screen.currentResolution.width;
        _screenCenter = new Vector2(w, h) / 2f;
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
        if (_world.InGameState is InGameState.Waiting) return;

        if (context.action.name is "Move")
        {
            MoveInput = context.ReadValue<Vector2>();

            if (context.started)
            {
                _onEndDrag.OnNext(new Vector2(MoveInput.x, 0));
            }
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        if (_world.InGameState is InGameState.Waiting) return;

        if (context.action.name is "Look")
        {
            LookInput = context.ReadValue<Vector2>();

            if (_mouseClicked)
            {
                var currentpos = Mouse.current.position.ReadValue() - _screenCenter;
                _onStartDrag.OnNext(currentpos - _screenCenter);
                _dragging = true;
            }
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (_world.InGameState is InGameState.Waiting) return;

        if (context.action.name is "Attack" && context.started)
        {
            _mouseClicked = true;
            FirstScreenPosOnDrag = Mouse.current.position.ReadValue() - _screenCenter;
        }
        else if (context.canceled && _mouseClicked)
        {
            _mouseClicked = false;

            if (_dragging)
            {
                _dragging = false;
                var nowPos = Mouse.current.position.ReadValue() - _screenCenter;
                _onEndDrag.OnNext(nowPos - FirstScreenPosOnDrag);
            }
        }

        if (context.action.name is "Attack" && context.performed)
        {
            OnAttackFired.OnNext(Unit.Default);
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (_world.InGameState is InGameState.Waiting) return;

        if (context.action.name is "Interact" && context.performed)
        {
            OnInteractFired.OnNext(Unit.Default);
        }
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (_world.InGameState is InGameState.Waiting) return;

        if (context.action.name is "Crouch" && context.performed)
        {
            OnCrouchFired.OnNext(Unit.Default);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (_world.InGameState is InGameState.Waiting) return;

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
        if (_world.InGameState is InGameState.Waiting) return;

        if (context.action.name is "Sprint" && context.performed)
        {
            OnSprintFired.OnNext(Unit.Default);
        }
    }
}