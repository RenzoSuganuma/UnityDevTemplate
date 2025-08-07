using Cysharp.Threading.Tasks;
using ImTipsyDude.InstantCS;
using R3;
using UnityEngine.UI;

public class CmpSlider : ICSComponent
{
    public ReactiveProperty<float> SliderValue { get; private set; } = new();

    private Slider _slider;

    public override void OnStart()
    {
        base.OnStart();

        _slider = GetComponent<Slider>();
        SliderValue.Subscribe(v => { _slider.value = v; }).AddTo(destroyCancellationToken);
    }
}