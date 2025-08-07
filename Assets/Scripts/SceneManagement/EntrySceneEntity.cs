using ImTipsyDude.InstantCS;
using R3;
using UnityEngine;

namespace ImTipsyDude.Scene
{
    public class EntrySceneEntity : SceneEntity
    {
        public override void OnStart()
        {
            ICSWorld.Instance.StartLoadNextScene("Level1");
        }

        public override void OnTerminate()
        {
        }
    }
}