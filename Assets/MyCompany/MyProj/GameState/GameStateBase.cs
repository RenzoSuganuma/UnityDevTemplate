using VContainer;
using VContainer.Unity;

namespace MyCompany.MyProj.GameState
{
    public class GameStateBase : IGameState
    {
        private GameStateBase _currentState;
        private readonly LifetimeScope _lifetimeScope;

        [Inject]
        public GameStateBase(LifetimeScope parentScope)
        {
            _lifetimeScope = parentScope.CreateChild(CreateBuilder);
        }

        protected virtual void CreateBuilder(IContainerBuilder builder)
        {
        }

        public virtual void OnStateInitialize()
        {
        }

        public virtual void OnStateFinalize()
        {
        }

        public virtual void Dispose()
        {
        }

        protected void RunNextState<T>() where T : GameStateBase
        {
            OnStateFinalize();
            _currentState = _lifetimeScope.Container.Resolve<T>();
            _currentState.OnStateInitialize();
        }
    }
}