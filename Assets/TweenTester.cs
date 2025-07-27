using System;
using DG.Tweening;
using ImTipsyDude.Player;
using ImTipsyDude.Tween;
using UnityEngine;

public class TweenTester : MonoBehaviour
{
    private void Start()
    {
        DOVirtual
            .Int(0, 8, 1f, value => { Debug.Log($"{value}"); })
            .AddToTweenPool();
    }
}