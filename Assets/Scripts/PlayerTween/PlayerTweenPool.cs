using System;
using System.Collections.Generic;
using DG.Tweening;
using ImTipsyDude.Player;
using UnityEngine;

namespace ImTipsyDude.Tween
{
    public class PlayerTweenPool : MonoBehaviour
    {
        public List<DG.Tweening.Tween> Tweens { get; private set; } = new();

        public static PlayerTweenPool Instance { get; private set; }

        private void Start()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        private void Update()
        {
            foreach (var tween in Tweens)
            {
                tween.ManualUpdate(PlayerTime.DeltaTime * PlayerTime.TimeScale, PlayerTime.UnscaledDeltaTime);
            }
        }
    }

    public static class TweenerExtension
    {
        public static void AddToTweenPool(this Tweener tweener)
        {
            var t = tweener.SetUpdate(UpdateType.Manual);
            PlayerTweenPool.Instance.Tweens.Add(t);
        }
    }
}