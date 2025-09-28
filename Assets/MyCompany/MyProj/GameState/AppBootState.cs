using Cysharp.Threading.Tasks;
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
            await UniTask.Yield();
            RunNextState<GameTitleState>();
        }
    }
}