using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using ImTipsyDude.Helper;
using ImTipsyDude.Player;
using ImTipsyDude.Scene;
using R3;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ImTipsyDude.InstantCS
{
    [RequireComponent(typeof(PauseResumer))]
    public sealed class ICSWorld : MonoBehaviour
    {
        [SerializeField] GameDimension _gameDimension;

        public GameDimension GameDimension => _gameDimension;

        public static ICSWorld Instance { get; private set; }
        public SceneEntity CurrentScene { get; private set; }

        public static SceneEntity GetScene() => Instance.CurrentScene;

        public T GetSceneAs<T>() where T : SceneEntity => Instance.CurrentScene as T;

        public InGameState InGameState { get; private set; }

        public event Action OnPaused
        {
            add => _pauseResumer.OnPaused += value;

            remove => _pauseResumer.OnPaused -= value;
        }

        public event Action OnResume
        {
            add => _pauseResumer.OnResume += value;

            remove => _pauseResumer.OnResume -= value;
        }

        public void UpdateInGameState(InGameState state) => InGameState = state;

        private PauseResumer _pauseResumer;

        private void Start()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            PlayerTime.TimeScale = 1;
            PlayerTime.DeltaTime = Time.deltaTime;
            PlayerTime.UnscaledDeltaTime = Time.unscaledDeltaTime;

            _pauseResumer = GetComponent<PauseResumer>();
        }

        public void SlowMotion()
        {
            PlayerTime.TimeScale = Time.timeScale = 0.5f;
            PlayerTime.DeltaTime = Time.deltaTime * PlayerTime.TimeScale;
            PlayerTime.UnscaledDeltaTime = Time.unscaledDeltaTime;

            DOTween.To(() => 100f, value => { }, 1000, 1) // ダミー
                .OnComplete(() =>
                {
                    PlayerTime.TimeScale = Time.timeScale = 1;
                    PlayerTime.DeltaTime = Time.deltaTime * PlayerTime.TimeScale;
                    PlayerTime.UnscaledDeltaTime = Time.unscaledDeltaTime;
                }).Play();
        }

        public void PauseResume()
        {
            _pauseResumer.PauseResume();
        }

        public void UpdateCurrentScene(SceneEntity scene)
        {
            CurrentScene = scene;
        }

        public void StartLoadNextScene(string nameNext)
        {
            var o = SceneManager.LoadSceneAsync(nameNext, LoadSceneMode.Additive);
            o.allowSceneActivation = false;
            GetScene().AsyncOperation = o;
        }

        public void UnLoadScene(string name, Action<AsyncOperation> callback)
        {
            var o = SceneManager.UnloadSceneAsync(name);
            GetScene().AsyncOperation.allowSceneActivation = true;
            o.completed += o => { callback(o); };
        }

        public void QuitGame()
        {
            Application.Quit();

#if UNITY_EDITOR
            if (EditorApplication.isPlaying)
            {
                EditorApplication.isPlaying = false;
            }
#endif
        }
    }
}