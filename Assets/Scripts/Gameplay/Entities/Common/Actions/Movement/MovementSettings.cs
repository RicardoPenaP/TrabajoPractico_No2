using UnityEngine;

namespace Gameplay.Entities.Common.Actions.Movement
{
    [CreateAssetMenu(fileName = "NewMovementSettings", menuName = "Gameplay/Common/Movement/Movement Settings")]
    public class MovementSettings : ScriptableObject
    {
        [Header("Movement Settings")]
        [SerializeField] private float _maxMovementSpeed = 20f;
        [SerializeField] private float _movementSpeed = 0f;
        public float movementSpeed => _movementSpeed;
        public float normalizedMovementSpeed => _movementSpeed / _maxMovementSpeed;

        public void SetNormalizedMovementSpeed(float normalizedValue)
        {
            if (normalizedValue > 1 || normalizedValue < 0)
            {
                Debug.Log("Parameter value is not a normalized value: " + normalizedValue.ToString());
                return;
            }

            _movementSpeed = _maxMovementSpeed * normalizedValue;
        }
    }
}