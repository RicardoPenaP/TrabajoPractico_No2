using System.Collections;
using UnityEngine;

namespace Gameplay.Entities.Common.Actions
{
    public abstract class LerpTargetActionController<T> : TargetActionController<T> where T : Component
    {
        #region Variables
        protected readonly MonoBehaviour _coroutineController = null;

        protected IEnumerator _currentCoroutine = null;

        protected bool _isLerping = false;
        #endregion

        #region Public Methods
        public LerpTargetActionController(T target, MonoBehaviour coroutineController) : base (target)
        {
            _coroutineController = coroutineController;
        }
        #endregion

        #region Virtual Methods
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
        #endregion

        #region Abstract Methods
        protected abstract IEnumerator LerpRoutine();
        #endregion
      
    }
}