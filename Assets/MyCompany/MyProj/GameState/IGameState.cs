using System;

namespace MyCompany.MyProj.GameState
{
    public interface IGameState : IDisposable
    {
        public void Initialize();
    }
}