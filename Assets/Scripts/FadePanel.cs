using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GameFramework
{
    public class FadePanel : MonoBehaviour
    {
        private static class OnRuntimeInit
        {
            [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
            private static void OnInit()
            {
                var panel = Object.Instantiate(Resources.Load<GameObject>("FadePanel"));
                Object.DontDestroyOnLoad(panel);
                panel.AddComponent<FadePanel>();
            }
        }

        private CanvasGroup m_canvasGroup;

        private void Start()
        {
            if (!TryGetComponent<CanvasGroup>(out m_canvasGroup))
            {
                m_canvasGroup = gameObject.AddComponent<CanvasGroup>();
            }
            
            Hide();
        }

        public void Show(float duration = 1.0f)
        {
            m_canvasGroup.DOFade(1f, duration);
        }

        public void Hide(float duration = 1.0f)
        {
            m_canvasGroup.DOFade(0f, duration);
        }
    }
}