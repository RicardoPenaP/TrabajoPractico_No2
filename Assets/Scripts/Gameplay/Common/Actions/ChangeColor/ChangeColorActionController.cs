using Gameplay.Input;
using System.Collections;
using UnityEngine;
using static UnityEngine.Input;

namespace Gameplay.Common.Actions.ChangeColor
{
    public class ChangeColorActionController : LerpTargetActionController<SpriteRenderer>
    {
        private readonly ChangeColorSettings _settings;       
        private readonly IChangeColorInputSettings _changeColorInputSettings;

        public ChangeColorActionController(
            ChangeColorSettings settings,
            SpriteRenderer targetSpriteRenderer,
            IChangeColorInputSettings changeColorInputSettings,
            MonoBehaviour coroutineController) : base(targetSpriteRenderer, coroutineController)
        {
            _settings = settings;            
            _changeColorInputSettings = changeColorInputSettings;
        }


        public override void UpdateAction()
        {
            if (_isLerping)
            {
                return;
            }

            if (GetKeyUp(_changeColorInputSettings.changeColorInputKey))
            {
                StartLerping();
            }
        }

        private Color GetRandomColor()
        {
            Color randomColor = Color.black;

            randomColor.r = Random.Range(0, 1f);
            randomColor.g = Random.Range(0, 1f);
            randomColor.b = Random.Range(0, 1f);

            return randomColor;
        }

        protected override IEnumerator LerpRoutine()
        {
            _isLerping = true;
            float timer = 0;

            Color targetColor = GetRandomColor();

            Vector3 startingValue = new Vector3(_target.color.r, _target.color.g, _target.color.b);
            Vector3 targetValue = new Vector3(targetColor.r, targetColor.g, targetColor.b);

            while (timer < _settings.lerpDuration)
            {
                timer = _settings.changeColorWithLerp ? timer + Time.deltaTime : _settings.lerpDuration;
                float progress = timer / _settings.lerpDuration;
                Vector3 currentValue = Vector3.Lerp(startingValue, targetValue, progress);
                Color currentColor = Color.black;
                currentColor.r = currentValue.x;
                currentColor.g = currentValue.y;
                currentColor.b = currentValue.z;
                _target.color = currentColor;
                yield return null;
            }

            _isLerping = false;
        }


    }
}

