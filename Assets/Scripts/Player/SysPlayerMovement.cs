using Cysharp.Threading.Tasks;
using ImTipsyDude.InstantECS;
using R3;
using UnityEngine;

namespace ImTipsyDude.Player
{
    public class SysPlayerMovement : IECSSystem
    {
        private Rigidbody _rigidbody;
        private TipsyPlayerInput _tipsyPlayerInput;
        private CmpPlayer _cmpPlayer;

        private void OnFired()
        {
        }

        private void OnInteract()
        {
        }

        private void OnCrouch()
        {
        }

        private void OnJump()
        {
        }

        private void OnSprint()
        {
        }

        private void Init()
        {
            if (Entity.World.GameDimension is GameDimension.TwoDimensional)
            {
                Entity.transform.position = Vector3.zero;
            }
        }

        private void PlayerMove2D()
        {
            var horInput = _tipsyPlayerInput.MoveInput.x;
            var velocity = horInput * Vector3.right;
            transform.forward = velocity.normalized;
            transform.position += velocity * Time.deltaTime;
        }

        private void PlayerMove3D()
        {
        }

        #region Event Functions

        public override void OnStart()
        {
            if (!gameObject.TryGetComponent(out _rigidbody))
            {
                _rigidbody = gameObject.AddComponent<Rigidbody>();
            }

            _cmpPlayer = GetComponent<CmpPlayer>();

            _tipsyPlayerInput = TipsyPlayerInput.Instance;
            _tipsyPlayerInput.OnAttackFired.Subscribe(_ => OnFired()).AddTo(destroyCancellationToken);
            _tipsyPlayerInput.OnInteractFired.Subscribe(_ => OnInteract()).AddTo(destroyCancellationToken);
            _tipsyPlayerInput.OnCrouchFired.Subscribe(_ => OnCrouch()).AddTo(destroyCancellationToken);
            _tipsyPlayerInput.OnJumpFired.Subscribe(_ => OnJump()).AddTo(destroyCancellationToken);
            _tipsyPlayerInput.OnSprintFired.Subscribe(_ => OnSprint()).AddTo(destroyCancellationToken);

            Init();
        }

        public override void OnUpdate()
        {
            if (Entity.World.GameDimension is GameDimension.ThreeDimensional)
            {
                PlayerMove3D();
            }
            else
            {
                PlayerMove2D();
            }
        }

        public override void OnFixedUpdate()
        {
        }

        public override void OnTerminate()
        {
        }

        #endregion
    }
}