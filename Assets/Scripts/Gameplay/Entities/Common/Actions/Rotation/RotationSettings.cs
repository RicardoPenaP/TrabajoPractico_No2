using UnityEngine;

namespace Gameplay.Entities.Common.Actions.Rotation
{
    [CreateAssetMenu(fileName = "NewRotationSettings", menuName = "Gameplay/Common/Rotation/Rotation Settings")]
    public class RotationSettings : ScriptableObject
    {
        [Header("Rotation Settings")]
        [SerializeField] private float _rotationStep = 10f;
        public float rotationStep => _rotationStep;

        [SerializeField] private bool _rotaeWithLerp = false;
        public bool rotateWithLerp => _rotaeWithLerp;

        [Tooltip("Lerp duration in seconds")]
        [SerializeField] private float _lerpDuration = 0.5f;
        public float lerpDuration => _lerpDuration;
    }
}