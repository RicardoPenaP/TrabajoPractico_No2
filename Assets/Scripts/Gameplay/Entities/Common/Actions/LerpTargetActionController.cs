using System.Collections;
using UnityEngine;

namespace Gameplay.Entities.Common.Actions
{
    public abstract class LerpTargetActionController<T> : TargetActionController<T> where T : Component
    {
        protected readonly MonoBehaviour _coroutineController = null;

        protected IEnumerator _currentCoroutine = null;

        protected bool _isLerping = false;

        public LerpTargetActionController(T target, MonoBehaviour coroutineController) : base (target)
        {
            _coroutineController = coroutineController;
        }

        protected virtual void StartLerping()
        {
            if (_isLerping)
            {
                return;
            }
            _isLerping = true;
            _currentCoroutine = LerpRoutine();
            _coroutineController.StartCoroutine(_currentCoroutine);
        }

        protected virtual void StopLerping()
        {
            if (_currentCoroutine is null)
            {
                return;
            }
            _coroutineController.StopCoroutine(_currentCoroutine);
            _currentCoroutine = null;
        }

        protected abstract IEnumerator LerpRoutine();
    }
}