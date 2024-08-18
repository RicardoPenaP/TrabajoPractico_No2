using UnityEngine;

namespace Gameplay.Entities.Common.Actions.ChangeColor
{
    [CreateAssetMenu(fileName = "NewChangeColorSettings", menuName = "Gameplay/Common/Color/Change Color Settings")]
    public class ChangeColorSettings : ScriptableObject
    {
        #region Editor Variables
        [Header("Change Color Settings")]
        [SerializeField] private bool _changeColorWithLerp = false;
        public bool changeColorWithLerp => _changeColorWithLerp;

        [SerializeField] private float _lerpDuration = 0.5f;
        public float lerpDuration => _lerpDuration;
        #endregion
       
    }
}