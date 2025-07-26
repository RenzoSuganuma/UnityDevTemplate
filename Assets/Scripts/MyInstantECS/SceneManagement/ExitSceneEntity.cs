using ImTipsyDude.InstantECS;

namespace ImTipsyDude.Scene
{
    public class ExitSceneEntity :  SceneEntity
    {
        public override void OnStart()
        {
            IECSWorld.Instance.StartLoadNextScene("Entry");
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