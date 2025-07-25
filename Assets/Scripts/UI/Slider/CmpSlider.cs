using Cysharp.Threading.Tasks;
using ImTipsyDude.InstantECS;
using R3;
using UnityEngine.UI;

public class CmpSlider : IECSComponent
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