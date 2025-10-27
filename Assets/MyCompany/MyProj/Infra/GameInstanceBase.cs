using UnityEngine;

namespace MyCompany.MyProj.Infra
{
    /// <summary> ランタイムが開始されるタイミングから有効になるインスタンス </summary>
    public class GameInstanceBase
    {
        private static GameInstanceBase _instanceBase;

        /// <summary> インスタンスを返す </summary>
        public static GameInstanceBase Get => _instanceBase;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void OnInitializedRuntime()
        {
            _instanceBase = new GameInstanceBase();
        }
    }
}