using ImTipsyDude.InstantECS;
using UnityEngine;

namespace ImTipsyDude.Camera
{
    public class EnPlayerCamera : IECSEntity
    {
        [SerializeField] private Transform _playerTransform;

        public Transform PlayerTransform => _playerTransform;
    }
}