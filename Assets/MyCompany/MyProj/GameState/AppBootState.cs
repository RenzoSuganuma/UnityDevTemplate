using Cysharp.Threading.Tasks;
using MyCompany.MyProj.Infra;
using UnityEngine;
using VContainer;
using Application = MyCompany.MyProj.Infra.Application;

namespace MyCompany.MyProj.GameState
{
    public class AppBootState : AppStateBase
    {
        [Inject]
        public AppBootState(Application lifetime) : base(lifetime)
        {
        }

        public override async UniTask InitAsync()
        {
            ShowLoadingScreen();
            await UniTask.Yield();
            //RunNextState<GameTitleState>();
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}