using ImTipsyDude.Helper;
using ImTipsyDude.InstantCS;
using TMPro;

public class CmpEntryWindow : ICSComponent
{
    private TMP_Text[] _texts;

    public TMP_Text[] Texts => _texts;

    public override void OnStart()
    {
        _texts = GetComponentsInChildren<TMP_Text>();
    }
}