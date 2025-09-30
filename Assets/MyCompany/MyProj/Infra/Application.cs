using Cysharp.Threading.Tasks;
using DG.Tweening;
using MyCompany.MyProj.GameState;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

namespace MyCompany.MyProj.Infra
{
    public sealed class Application : LifetimeScope
    {
        [SerializeField] private Image _loadingImage;

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
            if (Gamepad.current != null)
            {
                Debug.Log($"Gamepad {Gamepad.current.displayName}");
                _container.RegisterInstance(Gamepad.current);
                Gamepad.current.SetMotorSpeeds(10,0);
            }

            _container.Register<AppBootState>(Lifetime.Singleton);
            _container.Register<HapticsManager>(Lifetime.Singleton);

            _resolver = _container.Build();
            _currentState = _resolver.Resolve<AppBootState>();
            _currentState.InitAsync().Forget();

            _loadingImage.DOFade(0, .5f);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _resolver.Dispose();
            Gamepad.current.SetMotorSpeeds(0,0);
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

        public void ShowLoadingScreen() => _loadingImage.DOFade(1, 1f);

        public void HideLoadingScreen() => _loadingImage.DOFade(0, 1f);

        public HapticsManager GetGamepadVibration() => _resolver.Resolve<HapticsManager>();
    }
}