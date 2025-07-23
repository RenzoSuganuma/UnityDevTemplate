using ImTipsyDude.InstantECS;
using TMPro;
using UnityEngine;

public class EnNotification : IECSEntity
{
    public TMP_Text Text;
    public RectTransform Transform;
    public RectTransform Start;
    public RectTransform End;
    public CanvasGroup Group;
}