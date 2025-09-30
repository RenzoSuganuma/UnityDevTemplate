using UnityEngine.InputSystem;
using VContainer;

namespace MyCompany.MyProj.Infra
{
    public class HapticsManager
    {
        private readonly Gamepad _gamepad;

        [Inject]
        public HapticsManager(Application lifetime, Gamepad gamepad)
        {
            _gamepad = gamepad;
        }

        public void SetVibrationLowFreq(float f)
        {
            _gamepad?.SetMotorSpeeds(f, 0);
        }

        public void SetVibrationHighFreq(float f)
        {
            _gamepad?.SetMotorSpeeds(0, f);
        }

        public void ResetHaptics() => InputSystem.ResetHaptics();

        public void ResumeHaptics() => InputSystem.ResumeHaptics();
    }
}