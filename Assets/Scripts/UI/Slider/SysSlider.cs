using ImTipsyDude.InstantCS;

public class SysSlider : ICSSystem
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
}