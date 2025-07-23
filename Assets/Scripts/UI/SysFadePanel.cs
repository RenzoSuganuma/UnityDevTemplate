using System;
using System.Collections;
using DG.Tweening;
using ImTipsyDude.InstantECS;
using UnityEngine;

namespace ImTipsyDude
{
    public class SysFadePanel : IECSSystem
    {
        private CanvasGroup _canvasGroup;

        public override void OnStart()
        {
            if (!TryGetComponent<CanvasGroup>(out _canvasGroup))
            {
                _canvasGroup = gameObject.AddComponent<CanvasGroup>();
            }
        }

        public override void OnUpdate()
        {
        }

        public override void OnFixedUpdate()
        {
        }

        public override void OnTerminate()
        {
        }

        public void Show(float duration = 1.0f)
        {
            _canvasGroup.DOFade(1f, duration);
        }

        public void Hide(float duration = 1.0f)
        {
            _canvasGroup.DOFade(0f, duration);
        }
    }
}