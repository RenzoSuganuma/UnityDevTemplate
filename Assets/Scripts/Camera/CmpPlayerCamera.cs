using ImTipsyDude.InstantECS;
using UnityEngine;

namespace ImTipsyDude.Camera
{
    public class CmpPlayerCamera : IECSComponent
    {
        [SerializeField] private Vector3 _offset = Vector3.back * -10;

        public Vector3 Offset => _offset;
    }
}