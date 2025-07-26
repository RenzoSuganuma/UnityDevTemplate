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
        Entity.World.UnLoadScene("Entry", o => { });
    }

    public void QuitGame()
    {
        Entity.World.QuitGame();
    }

    public override void OnStart()
    {
        var c = GetComponent<CmpEntryWindow>();
        if (c == null) return;
        foreach (var t in c.Texts)
        {
            t.font = EnDependencyPool.Instance.FontAsset as TMP_FontAsset;
        }

        var entity = GetEntity<EnEntryWindow>();
        entity.EnterInGameButton.GetComponentInChildren<TMP_Text>().text = "ENTRY GAME";
        entity.ExitInGameButton.GetComponentInChildren<TMP_Text>().text = "QUIT GAME";
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