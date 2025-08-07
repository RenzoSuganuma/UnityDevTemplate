using ImTipsyDude.InstantCS;

namespace ImTipsyDude.Scene
{
    public class ExitSceneEntity :  SceneEntity
    {
        public override void OnStart()
        {
            ICSWorld.Instance.StartLoadNextScene("Entry");
        }

        public override void OnTerminate()
        {
        }
    }
}