using System;
using UnityEngine;

namespace Gameplay.Entities.Common.Actions
{
    public abstract class TargetActionController<T> : IUpdatableAction where T : Component
    {
        protected readonly T _target = null;

        protected TargetActionController(T target)
        {
            _target = target ?? throw new ArgumentNullException(nameof(target), "Target can't be null.");
        }

        public abstract void UpdateAction();
    }
}

