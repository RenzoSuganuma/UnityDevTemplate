using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using ImTipsyDude.InstantCS;
using UnityEngine;

namespace ImTipsyDude.Scene
{
    [DefaultExecutionOrder((int)ExecutionOrder.Scene)]
    public abstract class SceneEntity : MonoBehaviour
    {
        private Dictionary<int, ICSComponent> _components;
        private Dictionary<int, ICSSystem> _systems;

        public AsyncOperation AsyncOperation { get; set; }

        public abstract void OnStart();
        public abstract void OnTerminate();

        public void BindComponent(ICSComponent component)
            => _components.Add(component.ID, component);

        public void BindSystem(ICSSystem system)
            => _systems.Add(system.ID, system);

        public void PullComponent<T>(int componentId, out T component) where T : ICSComponent
        {
            component = _components[componentId] as T;
        }

        public void PullSystem<T>(int systemId, out T system) where T : ICSSystem
        {
            system = _systems[systemId] as T;
        }

        private void Start()
        {
            _components = new();
            _systems = new();
            ICSWorld.Instance.UpdateCurrentScene(this);
            OnStart();
        }

        private void OnDestroy()
        {
            _components?.Clear();
            _systems?.Clear();
            AsyncOperation = null;
            OnTerminate();
        }
    }
}