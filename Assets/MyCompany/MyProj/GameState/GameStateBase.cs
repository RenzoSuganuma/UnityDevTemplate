using VContainer;
using VContainer.Unity;

namespace MyCompany.MyProj.GameState
{
    public class GameStateBase : IGameState
    {
        private GameStateBase _currentState;
        private IObjectResolver Owner;
        protected LifetimeScope LifeTime;

        [Inject]
        public GameStateBase(IObjectResolver parentScope)
        {
            Owner = parentScope;
        }

        protected virtual void CreateBuilder(IContainerBuilder builder)
        {
        }

        public virtual void Initialize()
        {
        }

        public virtual void Dispose()
        {
        }

        protected void RunNextState<T>() where T : GameStateBase
        {
            _currentState?.Dispose();
            _currentState = LifeTime.Container.Resolve<T>();
            _currentState.Initialize();
        }
    }
}