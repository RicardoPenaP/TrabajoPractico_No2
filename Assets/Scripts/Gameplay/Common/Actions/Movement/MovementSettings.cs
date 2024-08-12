using UnityEngine;

namespace Gameplay.Common.Actions.Movement
{
    [CreateAssetMenu(fileName = "NewMovementSettings", menuName = "Gameplay/Common/Movement/Movement Settings")]
    public class MovementSettings : ScriptableObject
    {
        [Header("Movement Settings")]
        [SerializeField] private float _movementSpeed = 0f;
        public float movementSpeed => _movementSpeed;
    }
}