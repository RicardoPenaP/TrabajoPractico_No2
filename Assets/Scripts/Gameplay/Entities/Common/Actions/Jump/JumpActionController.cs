using Gameplay.Entities.Common.Actions.Movement;
using Gameplay.Input;
using System.Collections;
using UnityEngine;
using static UnityEngine.Input;

namespace Gameplay.Entities.Common.Actions.Jump
{
    public class JumpActionController : LerpTargetActionController<Transform>
    {
        #region Variables
        private readonly JumpSettings _settings;
        private readonly IJumpInputSettings _movementInputSettings;
        private readonly MovementActionController _movementController;
        #endregion

        #region Constructors
        public JumpActionController(
            JumpSettings settings,
            Transform targetTransform,
            IJumpInputSettings movementInputSettings,
            MonoBehaviour coroutineContoller,
            MovementActionController movementController) : base(targetTransform, coroutineContoller)
        {
            _settings = settings;            
            _movementInputSettings = movementInputSettings;
            _movementController = movementController;
        }
        #endregion

        #region Interface Methods
        public override void UpdateAction()
        {
            if (_isLerping)
            {
                return;
            }

            if (GetKeyDown(_movementInputSettings.jumpInputKey))
            {
                StartLerping();
            }
        }
        #endregion

        #region Coroutines
        protected override IEnumerator LerpRoutine()
        {
            float startingY = _target.position.y;
            float maxY = startingY + _settings.jumpDistance;
            float jumpDirection = 1;

            if (_movementController is not null)
            {
                _movementController.SetCanMoveVertically(false);
            }

            while (_isLerping)
            {
                _target.position += new Vector3(0, jumpDirection * _settings.jumpSpeed * Time.deltaTime, 0);

                if (_target.position.y >= maxY)
                {
                    jumpDirection *= -1;
                }

                if (_target.position.y <= startingY)
                {
                    _isLerping = false;
                }
                yield return null;
            }

            if (_movementController is not null)
            {
                _movementController.SetCanMoveVertically(true);
            }
        }
        

        #endregion



    }
}

