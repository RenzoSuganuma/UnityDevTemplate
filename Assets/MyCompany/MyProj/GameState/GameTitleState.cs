using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using VContainer;
using Application = MyCompany.MyProj.Infra.Application;

namespace MyCompany.MyProj.GameState
{
    public class GameTitleState : AppStateBase
    {
        [Inject]
        public GameTitleState(Application lifetime) : base(lifetime)
        {
        }

        public override async UniTask InitAsync()
        {
            await SceneManager.LoadSceneAsync("Scenes/Title", LoadSceneMode.Single).ToUniTask();
        }
    }
}