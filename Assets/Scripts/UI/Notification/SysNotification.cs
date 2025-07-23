using DG.Tweening;
using ImTipsyDude.InstantECS;

public class SysNotification : IECSSystem
{
    public override void OnStart()
    {
        var c = GetComponent<CmpNotification>();
        c.Text.text = $"{c.Title}\n{c.Content}";
        c.Transform.position = c.Start.position;
        DOTween.Sequence()
            .Append(c.Transform.DOMove(c.End.position, 1f))
            .Append(c.Group.DOFade(0f, 1f))
            .Play();
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