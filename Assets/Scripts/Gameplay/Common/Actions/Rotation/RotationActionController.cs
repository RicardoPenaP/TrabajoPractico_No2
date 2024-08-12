using Gameplay.Input;
using System.Collections;
using UnityEngine;
using static UnityEngine.Input;

namespace Gameplay.Common.Actions.Rotation
{
    public class RotationActionController : LerpTargetActionController<Transform>
    {
        private readonly RotationSettings _settings;
        private readonly IRotationInputSettings _movementInputSettings;

        private float _rotationDirection = 0f;

        public RotationActionController(
            RotationSettings settings,
            Transform targetTransform,
            IRotationInputSettings movementInputSettings,
            MonoBehaviour coroutineController) : base(targetTransform, coroutineController)
        {
            _settings = settings;
            _movementInputSettings = movementInputSettings;

        }

        public override void UpdateAction()
        {
            GetRotationInput();
        }

        private void GetRotationInput()
        {
            if (_isLerping)
            {
                return;
            }

            if (GetKeyDown(_movementInputSettings.rotateLeftInputKey))
            {
                _rotationDirection = 1f;
                StartLerping();
            }

            if (GetKeyDown(_movementInputSettings.rotateRightInputKey))
            {
                _rotationDirection = -1f;
                StartLerping();
            }
        }


        protected override IEnumerator LerpRoutine()
        {
            _isLerping = true;
            float timer = 0;
            Vector3 startingRotation = _target.rotation.eulerAngles;
            Vector3 targetRotation = startingRotation + new Vector3(0, 0, _settings.rotationStep * _rotationDirection);

            while (timer < _settings.lerpDuration)
            {
                timer = _settings.rotateWithLerp ? timer + Time.deltaTime : _settings.lerpDuration;
                float progress = timer / _settings.lerpDuration;
                Vector3 currentRotation = Vector3.Lerp(startingRotation, targetRotation, progress);
                _target.eulerAngles = currentRotation;
                yield return null;
            }

            _isLerping = false;
        }
    }
}

