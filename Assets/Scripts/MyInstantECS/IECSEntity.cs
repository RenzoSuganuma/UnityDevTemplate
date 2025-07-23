using R3;
using UnityEngine;

namespace ImTipsyDude.InstantECS
{
    /// <summary>
    /// NOTE:
    /// エンティティには依存関係を集める。SerializedFeildの宣言してよい
    /// </summary>
    [DefaultExecutionOrder((int)ExecutionOrder.EntityOrComponent)]
    public class IECSEntity : MonoBehaviour
    {
        public Subject<Unit> EvnOnKilled = new();
        public IECSComponent[] EcsComponents => GetComponents<IECSComponent>();
        public IECSSystem[] EcsSystems => GetComponents<IECSSystem>();
        public IECSWorld World => IECSWorld.Instance;
    }
}