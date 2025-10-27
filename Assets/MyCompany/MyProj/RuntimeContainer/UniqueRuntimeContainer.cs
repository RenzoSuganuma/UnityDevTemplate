using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

namespace MyCompany.MyProj.RuntimeContainer
{
    /// <summary> アプリケーションが破棄されるまで生き続けるコンテナ </summary>
    public sealed class UniqueRuntimeContainer : RuntimeContainerBase
    {
        private static UniqueRuntimeContainer _instance;

        /// <summary> インスタンスを返す </summary>
        public static UniqueRuntimeContainer Get => _instance;

        protected override void Awake()
        {
            base.Awake();
            if (_instance != null)
            {
                return;
            }

            _instance = this;
            UnityEngine.Object.DontDestroyOnLoad(this.gameObject);
        }
    }
}