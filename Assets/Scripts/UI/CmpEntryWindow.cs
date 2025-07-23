using ImTipsyDude.Helper;
using ImTipsyDude.InstantECS;
using TMPro;

public class CmpEntryWindow : IECSComponent
{
    private TMP_Text[] _texts;

    public TMP_Text[] Texts => _texts;

    public override void OnStart()
    {
        _texts = GetComponentsInChildren<TMP_Text>();
        EnInstanceIdPool.Instance.Map.TryAdd(nameof(CmpEntryWindow), ID);
    }

    public override void OnUpdate()
    {
    }

    public override void OnFixedUpdate()
    {
    }

    public override void OnTerminate()
    {
    }
}