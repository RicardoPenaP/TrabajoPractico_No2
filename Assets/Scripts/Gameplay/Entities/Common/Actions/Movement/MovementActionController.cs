using Gameplay.Input;
using UnityEngine;
using static UnityEngine.Input;

namespace Gameplay.Entities.Common.Actions.Movement
{
    public class MovementActionController : TargetActionController<Transform>
    {
        #region Variables
        private readonly MovementSettings _settings = null;        
        private readonly IMovementInputSettings _movementInputSettings = null;
        private bool _canMoveVertically = true;
        #endregion

        #region Constructors
        public MovementActionController(
            MovementSettings settings,
            Transform targetTransform,
            IMovementInputSettings movementInputSettings) : base (targetTransform)
        {
            _settings = settings;            
            _movementInputSettings = movementInputSettings;
        }
        #endregion

        #region Interface Methods
        public override void UpdateAction()
        {
            SetMovementInput();
        }
        #endregion

        #region Public Methods
        public void SetCanMoveVertically(bool state)
        {
            _canMoveVertically = state;
        }
        #endregion
        
        #region Private Methods
        private void SetMovementInput()
        {
            if (_movementInputSettings.useMouseInput)
            {
                MoveByMouseInput();
            }
            else
            {
                MoveByKeyboardInput();
            }
        }

        private void Move(Vector2 movementDirection)
        {
            _target.position = (Vector2)_target.position + movementDirection * _settings.movementSpeed * Time.deltaTime;
            SetFacingDirection(movementDirection.x);
        }
        
        private void SetFacingDirection(float direction)
        {
            Debug.Log(direction);
            if (Mathf.Abs(direction) <= Mathf.Epsilon)
            {
                return;
            }
            Vector3 newFacingDirection = _target.localScale;
            newFacingDirection.x = direction;
            _target.localScale = newFacingDirection;
        }

        private void MoveByMouseInput()
        {
            if (!GetMouseButton(0))
            {
                return;
            }

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector2 movementDirection = (mousePos - (Vector2)_target.position).normalized;
            movementDirection = _canMoveVertically ? movementDirection : new Vector2(movementDirection.x, 0f);

            Move(movementDirection);
        }

        private void MoveByKeyboardInput()
        {
            Vector2 movementDirection = Vector2.zero;

            if (_canMoveVertically)
            {
                if (GetKey(_movementInputSettings.moveUpInputKey))
                {
                    movementDirection.y += 1;
                }

                if (GetKey(_movementInputSettings.moveDownInputKey))
                {
                    movementDirection.y -= 1;
                }
            }

            if (GetKey(_movementInputSettings.moveLeftInputKey))
            {
                movementDirection.x -= 1;
            }

            if (GetKey(_movementInputSettings.moveRightInputKey))
            {
                movementDirection.x += 1;
            }

            if (movementDirection == Vector2.zero)
            {
                return;
            }

            Move(movementDirection.normalized);
        }
        #endregion


    }
}

