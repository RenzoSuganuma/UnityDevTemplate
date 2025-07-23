using System;
using Cysharp.Threading.Tasks;
using ImTipsyDude.Helper;
using ImTipsyDude.InstantECS;
using R3;
using TMPro;
using UnityEngine;

public class SysEntryWindow : IECSSystem
{
    public void EnterInGame()
    {
        Entity.World.UnLoadSceneAsync("Entry", o => { });
    }

    public override void OnStart()
    {
        GetEntity<EnEntryWindow>()
            .World.CurrentScene
            .PullComponent(EnInstanceIdPool.Instance.Map[nameof(CmpEntryWindow)], out var temp);
        var c = temp as CmpEntryWindow;
        if (c == null) return;
        foreach (var t in c.Texts)
        {
            t.font = EnDependencyPool.Instance.FontAsset as TMP_FontAsset;
        }
    }

    public override void OnUpdate()
    {
        var e = GetEntity<EnEntryWindow>();
        var condition = e.World.CurrentScene.AsyncOperation.progress >= 0.9f;
        e.EnterInGameButton.interactable = condition;
    }

    public override void OnFixedUpdate()
    {
    }

    public override void OnTerminate()
    {
    }
}