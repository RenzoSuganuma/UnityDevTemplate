using UnityEngine;

namespace ImTipsyDude.InstantCS
{
    /// <summary>
    /// NOTE:
    /// コンポーネントにはデータのみ集めておく。依存関係は集めない。
    /// </summary>
    [DefaultExecutionOrder((int)ExecutionOrder.Component)]
    public class ICSComponent : MonoBehaviour
    {
        public int ID => GetInstanceID();

        public virtual void OnStart()
        {
        }

        private void Start()
        {
            ICSWorld.GetScene().BindComponent(this);
            OnStart();
        }
    }
}