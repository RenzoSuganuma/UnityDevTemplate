using ImTipsyDude.Consts;
using ImTipsyDude.InstantCS;
using UnityEngine;
using UnityEngine.UI;

public class SysCanvasSize : ICSSystem
{
    [SerializeField] private Vector2 _referenceSize = Consts.Resolution.FullHD;

    public override void OnStart()
    {
        var canvas = GetComponent<CanvasScaler>();
        canvas.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        canvas.referenceResolution = _referenceSize;
    }
}