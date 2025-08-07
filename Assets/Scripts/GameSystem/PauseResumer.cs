using System;
using UnityEngine;

namespace ImTipsyDude.Helper
{
    public class PauseResumer : MonoBehaviour
    {
        
        public event Action OnPaused;
        public event Action OnResume;

        private bool _isPaused;
        
        public void PauseResume()
        {
            switch (_isPaused)
            {
                case false: // On Pause
                    Debug.Log("Pause");
                    OnPaused?.Invoke();
                    break;
                case true: // On Resume
                    Debug.Log("Resume");
                    OnResume?.Invoke();
                    break;
            }

            _isPaused = !_isPaused; // Toggle
        }
    }
}