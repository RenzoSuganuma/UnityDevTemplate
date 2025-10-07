using MyCompany.MyProj.GameState;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace TestModules
{
    public sealed class BootState : GameStateBase
    {
        public BootState(LifetimeScope parentScope) : base(parentScope.Container)
        {
            LifeTime = parentScope.CreateChild(CreateBuilder);
        }

        protected override void CreateBuilder(IContainerBuilder builder)
        {
            builder.Register<NextState>(Lifetime.Singleton);
        }

        public override void Initialize()
        {
            Debug.Log("[log] BOOT ");

            RunNextState<NextState>();

            base.Initialize();
        }

        public override void Dispose()
        {
            Debug.Log("[log] DISPOSE ");

            base.Dispose();
        }
    }
}