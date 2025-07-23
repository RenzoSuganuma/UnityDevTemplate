using System;
using System.Collections.Generic;
using ImTipsyDude.InstantECS;

namespace ImTipsyDude.Helper
{
    public class EnInstanceIdPool : IECSEntity
    {
        public static EnInstanceIdPool Instance {get; private set; }
        
        public Dictionary<string, int> Map = new();

        private void Start()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
    }
}