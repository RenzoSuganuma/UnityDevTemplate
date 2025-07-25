using ImTipsyDude.InstantECS;

public class SysSlider : IECSSystem
{
    private CmpSlider _cmpSlider;

    public void SetValue(float value)
    {
        _cmpSlider.SliderValue.Value = value;
    }

    public override void OnStart()
    {
        _cmpSlider = GetComponent<CmpSlider>();
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