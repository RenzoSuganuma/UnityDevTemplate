using ImTipsyDude.InstantECS;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CmpNotification : IECSComponent
{
    public string Title;
    public string Content;
}