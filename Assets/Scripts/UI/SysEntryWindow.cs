using System;
using Cysharp.Threading.Tasks;
using ImTipsyDude.InstantECS;
using R3;

public class SysEntryWindow : IECSSystem
{
    public void EnterInGame()
    {
        Entity.World.UnLoadSceneAsync("Entry", o => { });
    }

    public override void OnStart()
    {
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