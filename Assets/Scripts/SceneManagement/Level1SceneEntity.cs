using DG.Tweening;
using ImTipsyDude.Helper;
using ImTipsyDude.InstantCS;
using R3;
using TMPro;
using UnityEngine;

namespace ImTipsyDude.Scene
{
    public class Level1SceneEntity : SceneEntity
    {
        [SerializeField] private TMP_Text _countDownText;

        public Subject<Unit> OnStartGame = new Subject<Unit>();

        public override void OnStart()
        {
            ICSWorld.Instance.StartLoadNextScene("Exit");
        }

        public override void OnTerminate()
        {
            InstanceIdPool.Instance.Map.Clear();
        }
    }
}