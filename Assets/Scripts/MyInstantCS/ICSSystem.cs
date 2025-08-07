using System;
using UnityEngine;

namespace ImTipsyDude.InstantCS
{
    /// <summary>
    /// NOTE:
    /// システムにはデータに基づいた機能を集める（実装する）
    /// </summary>
    [DefaultExecutionOrder((int)ExecutionOrder.System)]
    public abstract class ICSSystem : MonoBehaviour
    {
        public int ID => GetInstanceID();

        public abstract void OnStart();

        private void Start()
        {
            ICSWorld.GetScene().BindSystem(this);
            OnStart();
        }
    }
}