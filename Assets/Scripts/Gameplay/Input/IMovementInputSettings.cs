using UnityEngine;

namespace Gameplay.Input
{
    public interface IMovementInputSettings 
    {
        public bool useMouseInput { get; }
        
        public KeyCode moveUpInputKey { get; }
        
        public KeyCode moveDownInputKey { get; }
       
        public KeyCode moveLeftInputKey { get; }
        
        public KeyCode moveRightInputKey { get; }
    }
}