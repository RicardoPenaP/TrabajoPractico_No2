using Gameplay.Common.Actions;
using Gameplay.Common.Actions.ChangeColor;
using Gameplay.Common.Actions.Jump;
using Gameplay.Common.Actions.Movement;
using Gameplay.Common.Actions.Rotation;
using Gameplay.Input;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Square
{
    public class SquareController : MonoBehaviour
    {
        [Header("Square Controller")]
        [Header("References")]
        [SerializeField] private InputSettings _inputSettings = null;
        [SerializeField] private MovementSettings _movementSettings = null;
        [SerializeField] private RotationSettings _rotationSettings = null;
        [SerializeField] private ChangeColorSettings _changeColorSettings = null;
        [SerializeField] private SpriteRenderer _spriteRenderer = null;
        [SerializeField] private JumpSettings _jumpSettings = null;

        private List<IUpdatableAction> _actionControllers = new List<IUpdatableAction>();

        private MovementActionController _movementController = null;
        private RotationActionController _rotationController = null;
        private ChangeColorActionController _changeColorController = null;
        private JumpActionController _jumpController = null;

        private void Awake()
        {
            _movementController = new MovementActionController(_movementSettings, transform, _inputSettings);
            _rotationController = new RotationActionController(_rotationSettings, transform, _inputSettings, this);
            _changeColorController = new ChangeColorActionController(_changeColorSettings, _spriteRenderer, _inputSettings, this);
            _jumpController = new JumpActionController(_jumpSettings, transform, _inputSettings, this, _movementController);

            _actionControllers.Add(_movementController);
            _actionControllers.Add(_rotationController);
            _actionControllers.Add(_changeColorController);
            _actionControllers.Add(_jumpController);
        }

        private void Update()
        {
            UpdateControllers();
        }

        private void UpdateControllers()
        {
            if (_actionControllers is null || _actionControllers.Count is 0)
            {
                return;
            }

            foreach (IUpdatableAction actionController in _actionControllers)
            {
                actionController.UpdateAction();
            }
        }
    }
}

