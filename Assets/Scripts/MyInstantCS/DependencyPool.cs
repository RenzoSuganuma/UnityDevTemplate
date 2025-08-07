using System;
using ImTipsyDude.InstantCS;
using TMPro;
using UnityEngine;

namespace ImTipsyDude.Helper
{
    public class DependencyPool : MonoBehaviour
    {
        public static DependencyPool Instance { get; private set; }
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