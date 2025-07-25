using DG.Tweening;
using ImTipsyDude.InstantECS;

public class SysNotification : IECSSystem
{
    private Sequence _seq;
    private EnNotification _enNotification;
    private CmpNotification _cmpNotification;

    public override void OnStart()
    {
        _enNotification = GetEntity<EnNotification>();
        _cmpNotification = GetComponent<CmpNotification>();
        _seq = DOTween.Sequence()
            .Append(_enNotification.Transform.DOMove(_enNotification.End.position, 1f))
            .Append(_enNotification.Group.DOFade(0f, 1f));

        Notify(_cmpNotification.Title, _cmpNotification.Content);
    }

    public void Notify(string title, string content)
    {
        _enNotification.Text.text =
            $"{title}\n{content}";
        _enNotification.Transform.position =
            _enNotification.Start.position;

        _seq.Play();
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