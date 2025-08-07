using System;
using Cysharp.Threading.Tasks;
using ImTipsyDude.Helper;
using ImTipsyDude.InstantCS;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SysEntryWindow : ICSSystem
{
    public Button EnterInGameButton;
    public Button ExitInGameButton;

    public void EnterInGame()
    {
        ICSWorld.Instance.UnLoadScene("Entry", o => { });
    }

    public void QuitGame()
    {
        ICSWorld.Instance.QuitGame();
    }

    public override void OnStart()
    {
        var c = GetComponent<CmpEntryWindow>();
        if (c == null) return;
        foreach (var t in c.Texts)
        {
            t.font = DependencyPool.Instance.FontAsset as TMP_FontAsset;
        }

        EnterInGameButton.GetComponentInChildren<TMP_Text>().text = "ENTRY GAME";
        ExitInGameButton.GetComponentInChildren<TMP_Text>().text = "QUIT GAME";
    }
}