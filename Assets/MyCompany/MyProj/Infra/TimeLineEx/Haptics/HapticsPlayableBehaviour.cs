using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace MyCompany.MyProj.Infra.TimeLineEx.Haptics
{
    [Serializable]
    public class HapticsPlayableBehaviour : PlayableBehaviour
    {
        private HapticsOperatingMode _operatingMode;
        float _lowFrequency;
        float _highFrequency;

        public HapticsPlayableBehaviour()
        {
        }

        public HapticsPlayableBehaviour(HapticsOperatingMode mode, float lowFrequency, float highFrequency)
        {
            _operatingMode = mode;
            _lowFrequency = lowFrequency;
            _highFrequency = highFrequency;
        }

        public override void OnBehaviourPlay(Playable playable, FrameData info)
        {
            if (Gamepad.current != null)
            {
                switch (_operatingMode)
                {
                    case HapticsOperatingMode.Vibrate:
                        Gamepad.current.SetMotorSpeeds(_lowFrequency, _highFrequency);
                        break;
                    case HapticsOperatingMode.Resume:
                        Gamepad.current.ResetHaptics();
                        break;
                    case HapticsOperatingMode.Reset:
                        Gamepad.current.ResetHaptics();
                        break;
                }
            }
        }

        public override void OnBehaviourPause(Playable playable, FrameData info)
        {
            if (Gamepad.current != null)
            {
                switch (_operatingMode)
                {
                    case HapticsOperatingMode.Vibrate:
                        Gamepad.current.SetMotorSpeeds(0, 0);
                        break;
                }
            }
        }
    }
}