using UnityEngine;

namespace Gameplay.Entities.Common.Actions.Jump
{
    [CreateAssetMenu(fileName = "NewJumpSettings", menuName = "Gameplay/Common/Jump/Jump Settings")]
    public class JumpSettings : ScriptableObject
    {
        [Header("Jump Settings")]
        [SerializeField] private float _jumpDistance = 2f;
        public float jumpDistance => _jumpDistance;

        [Tooltip("The distance traveled per second")]
        [SerializeField] private float _jumpSpeed = 0.1f;
        public float jumpSpeed => _jumpSpeed;
    }
}