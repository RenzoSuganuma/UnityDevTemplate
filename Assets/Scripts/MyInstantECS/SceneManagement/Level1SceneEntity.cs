using ImTipsyDude.InstantECS;

namespace ImTipsyDude.Scene
{
    public class Level1SceneEntity : SceneEntity
    {
        public override void OnStart()
        {
            IECSWorld.Instance.StartLoadNextScene("Exit");
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
}