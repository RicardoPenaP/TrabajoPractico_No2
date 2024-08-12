using UnityEngine;

namespace Gameplay.Input
{
    [CreateAssetMenu(fileName = "NewInputSettings", menuName = "Gameplay/Input/Input Settings")]
    public class InputSettings : 
        ScriptableObject,
        IMovementInputSettings, 
        IRotationInputSettings, 
        IChangeColorInputSettings, 
        IJumpInputSettings
    {
        [Header("Input Settings")]
        [Header("Movement Settings")]
        [SerializeField] private bool _useMouseInput = false;
        public bool useMouseInput => _useMouseInput;

        [SerializeField] private KeyCode _moveUpInputKey = KeyCode.None;
        public KeyCode moveUpInputKey => _moveUpInputKey;

        [SerializeField] private KeyCode _moveDownInputKey = KeyCode.None;
        public KeyCode moveDownInputKey => _moveDownInputKey;

        [SerializeField] private KeyCode _moveLeftInputKey = KeyCode.None;
        public KeyCode moveLeftInputKey => _moveLeftInputKey;

        [SerializeField] private KeyCode _moveRightInputKey = KeyCode.None;
        public KeyCode moveRightInputKey => _moveRightInputKey;

        [Header("Rotation Settings")]
        [SerializeField] private KeyCode _rotateLeftInputKey = KeyCode.None;
        public KeyCode rotateLeftInputKey => _rotateLeftInputKey;

        [SerializeField] private KeyCode _rotateRightInputKey = KeyCode.None;
        public KeyCode rotateRightInputKey => _rotateRightInputKey;

        [Header("Change Color Settings")]
        [SerializeField] private KeyCode _changeColorInputKey = KeyCode.None;
        public KeyCode changeColorInputKey => _changeColorInputKey;

        [Header("Jump Settings")]
        [SerializeField] private KeyCode _jumpInputKey = KeyCode.None;
        public KeyCode jumpInputKey => _jumpInputKey;

    }
}

