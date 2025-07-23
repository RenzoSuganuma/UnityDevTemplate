using DG.Tweening;
using ImTipsyDude.InstantECS;

public class SysNotification : IECSSystem
{
    public override void OnStart()
    {
        var entity = GetEntity<EnNotification>();
        var c = GetComponent<CmpNotification>();
        entity.Text.text = $"{c.Title}\n{c.Content}";
        entity.Transform.position = entity.Start.position;
        DOTween.Sequence()
            .Append(entity.Transform.DOMove(entity.End.position, 1f))
            .Append(entity.Group.DOFade(0f, 1f))
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