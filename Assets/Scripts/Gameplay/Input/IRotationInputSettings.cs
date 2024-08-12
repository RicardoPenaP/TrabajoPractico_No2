using UnityEngine;

namespace Gameplay.Input
{
    public interface IRotationInputSettings 
    {
        public KeyCode rotateLeftInputKey { get; }
        public KeyCode rotateRightInputKey { get; }
    }
}