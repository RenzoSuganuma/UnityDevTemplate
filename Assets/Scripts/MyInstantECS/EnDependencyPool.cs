using System;
using ImTipsyDude.InstantECS;
using TMPro;
using UnityEngine;

namespace ImTipsyDude.Helper
{
    public class EnDependencyPool : IECSEntity
    {
        public static EnDependencyPool Instance { get; private set; }
        public TMP_Asset FontAsset;

        private void Start()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
    }
}