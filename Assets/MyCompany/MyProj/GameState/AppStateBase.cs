using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Application = MyCompany.MyProj.Infra.Application;

namespace MyCompany.MyProj.GameState
{
    public class AppStateBase : IDisposable
    {
        private readonly Application _lifetime;

        [Inject]
        public AppStateBase(Application lifetime)
        {
            _lifetime = lifetime;
        }

        public virtual async UniTask InitAsync()
        {
            await UniTask.Yield();
        }
        
        public virtual void Dispose()
        {
        }

        protected void RunNextState<T>() where T : AppStateBase
        {
            _lifetime?.RunNextState<T>();
        }
        
        public void ShowLoadingScreen()
        {
            _lifetime?.ShowLoadingScreen();
        }
        
        public void HideLoadingScreen()
        {
            _lifetime?.HideLoadingScreen();
        }
    }
}