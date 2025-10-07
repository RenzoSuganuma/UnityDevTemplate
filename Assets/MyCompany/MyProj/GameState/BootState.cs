using System;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MyCompany.MyProj.GameState
{
    public sealed class BootState : GameStateBase
    {
        public BootState(LifetimeScope parentScope) : base(parentScope)
        {
        }
    }
}