using System;
using ImTipsyDude;
using ImTipsyDude.InstantECS;
using UnityEngine;
using UnityEngine.UI;

public class EnEntryWindow : IECSEntity
{
    [SerializeField] private Button _enterInGameButton;
    [SerializeField] private Button _exitInGameButton;
    
    public Button EnterInGameButton => _enterInGameButton;
}