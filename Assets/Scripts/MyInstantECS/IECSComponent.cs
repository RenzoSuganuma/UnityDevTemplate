using UnityEngine;

namespace ImTipsyDude.InstantECS
{
    /// <summary>
    /// NOTE:
    /// コンポーネントにはデータのみ集めておく。依存関係は集めない。
    /// </summary>
    
    [DefaultExecutionOrder((int)ExecutionOrder.EntityOrComponent)]
    public abstract class IECSComponent : MonoBehaviour
    {
        public int ID => GetInstanceID();

        public abstract void OnStart();
        public abstract void OnUpdate();
        public abstract void OnFixedUpdate();
        public abstract void OnTerminate();

        public IECSEntity Entity => gameObject.GetComponent<IECSEntity>();

        private void Start()
        {
            IECSWorld.GetScene().BindComponent(this);
            OnStart();
        }

        private void Update()
        {
            OnUpdate();
        }

        private void FixedUpdate()
        {
            OnFixedUpdate();
        }

        private void OnDestroy()
        {
            OnTerminate();
        }
    }
}