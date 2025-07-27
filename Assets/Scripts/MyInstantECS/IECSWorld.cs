using System;
using Cysharp.Threading.Tasks;
using ImTipsyDude.Player;
using ImTipsyDude.Scene;
using R3;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ImTipsyDude.InstantECS
{
    public sealed class IECSWorld : MonoBehaviour
    {
        [SerializeField] GameDimension _gameDimension;

        public GameDimension GameDimension => _gameDimension;

        public static IECSWorld Instance { get; private set; }
        public SceneEntity CurrentScene { get; private set; }

        public static SceneEntity GetScene() => Instance.CurrentScene;

        private void Start()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            PlayerTime.TimeScale = 1;
            PlayerTime.DeltaTime = Time.deltaTime;
            PlayerTime.UnscaledDeltaTime = Time.unscaledDeltaTime;
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

            if (EditorApplication.isPlaying)
            {
                EditorApplication.isPlaying = false;
            }
        }

        public void CreateEntity(out GameObject newEntity, GameObject prefab = null)
        {
            if (prefab != null)
            {
                if (!prefab.TryGetComponent<IECSEntity>(out var _))
                {
                    newEntity = null;
                    return;
                }
            }

            newEntity = Instantiate(prefab);
            newEntity.AddComponent<IECSEntity>();
        }
    }
}