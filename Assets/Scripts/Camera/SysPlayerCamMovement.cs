using ImTipsyDude.InstantECS;
using UnityEngine;

namespace ImTipsyDude.Camera
{
    public class SysPlayerCamMovement : IECSSystem
    {
        private CmpPlayerCamera _cmpPlayerCam;

        private void Move2D()
        {
            var en = GetEntity<EnPlayerCamera>();
            transform.forward = Vector3.forward;
            var newPos = en.PlayerTransform.position + _cmpPlayerCam.Offset;
            transform.position = newPos;
        }

        private void Move3D()
        {
        }

        #region Event Functions

        public override void OnStart()
        {
            _cmpPlayerCam = gameObject.GetComponent<CmpPlayerCamera>();
        }

        public override void OnUpdate()
        {
            if (Entity.World.GameDimension is GameDimension.ThreeDimensional)
            {
                Move3D();
            }
            else
            {
                Move2D();
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