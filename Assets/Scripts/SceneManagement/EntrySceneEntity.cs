using ImTipsyDude.InstantECS;
using R3;
using UnityEngine;

namespace ImTipsyDude.Scene
{
    public class EntrySceneEntity : SceneEntity
    {
        public override void OnStart()
        {
            IECSWorld.Instance.StartLoadNextScene("Level1");
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