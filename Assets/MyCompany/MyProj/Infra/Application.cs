using Cysharp.Threading.Tasks;
using MyCompany.MyProj.GameState;
using VContainer;
using VContainer.Unity;

namespace MyCompany.MyProj.Infra
{
    public sealed class Application : LifetimeScope
    {
        private ContainerBuilder _container;
        private IObjectResolver _resolver;

        private AppStateBase _currentState;

        public static Application Instance { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            if (Instance != null)
                Destroy(gameObject);

            Instance = this;
            DontDestroyOnLoad(gameObject);
            _container = new ContainerBuilder();
            _container.RegisterInstance(this);
            _container.Register<AppBootState>(Lifetime.Singleton);
            _resolver = _container.Build();
            _currentState = _resolver.Resolve<AppBootState>();
            _currentState.InitAsync().Forget();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _resolver.Dispose();
        }

        public void RunNextState<T>() where T : AppStateBase
        {
            if (!_resolver.TryResolve(out T _))
            {
                _container.Register<T>(Lifetime.Singleton);
                _resolver = _container.Build();
            }

            var next = _resolver.Resolve<T>();
            _currentState?.Dispose();
            _currentState = next;
            _currentState.InitAsync().Forget();
        }
    }
}