using System.Linq;
using Cysharp.Threading.Tasks;
using MyCompany.MyProj.Settings;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine.SceneManagement;
using VContainer;
using Application = MyCompany.MyProj.Infra.Application;

namespace MyCompany.MyProj.GameState
{
    public class GameTitleState : AppStateBase
    {
        private readonly Application _application;

        [Inject]
        public GameTitleState(Application lifetime) : base(lifetime)
        {
            _application = lifetime;
        }

        public override async UniTask InitAsync()
        {
            await SceneManager.LoadSceneAsync("Scenes/Title", LoadSceneMode.Single).ToUniTask();
        }
    }
}