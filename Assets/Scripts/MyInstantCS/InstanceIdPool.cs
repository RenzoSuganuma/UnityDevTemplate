using System;
using System.Collections.Generic;
using ImTipsyDude.InstantCS;
using UnityEngine;

namespace ImTipsyDude.Helper
{
    public class InstanceIdPool : MonoBehaviour
    {
        public static InstanceIdPool Instance {get; private set; }
        
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