using System;
using UnityEngine;

namespace Gameplay.Entities.Common.Actions
{
    public abstract class TargetActionController<T> : IUpdatableAction where T : Component
    {
        #region Variables
        protected readonly T _target = null;
        #endregion

        #region Constructors
        protected TargetActionController(T target)
        {
            _target = target ?? throw new ArgumentNullException(nameof(target), "Target can't be null.");
        }
        #endregion

        #region Abstrac Methods
        public abstract void UpdateAction();
        #endregion
       
    }
}

