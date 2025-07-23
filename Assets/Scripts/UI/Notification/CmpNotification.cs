using ImTipsyDude.InstantECS;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CmpNotification : IECSComponent
{
    public string Title;
    public string Content;
    public TMP_Text Text;
    public RectTransform Transform;
    public RectTransform Start;
    public RectTransform End;
    public CanvasGroup Group;
}