using MyCompany.MyProj.GameState;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace TestModules
{
    public class NextState : GameStateBase
    {
        [Inject]
        public NextState(LifetimeScope parentScope) : base(parentScope.Container)
        {
        }

        public override void Initialize()
        {
            Debug.Log("[log] INITIALIZE NEXT STATE");

            base.Initialize();
        }

        public override void Dispose()
        {
            Debug.Log("[log] DISPOSE NEXT STATE");

            base.Dispose();
        }
    }
}