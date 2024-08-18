using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menus.Common
{
    public class SliderWithText : MonoBehaviour
    {
        #region Editor Variables
        [Header("Slider With Text")]
        [Header("References")] 
        [SerializeField] private Slider _slider = null;
        [SerializeField] private TextMeshProUGUI _text = null;
        #endregion

        #region Events
        public event Action<float> OnSliderValueChangeEvent;
        #endregion

        #region Unity Methods
        private void Awake()
        {
            _slider.onValueChanged.AddListener(Slider_OnValueChange);
        }
        
        private void OnDestroy()
        {
            _slider.onValueChanged.RemoveListener(Slider_OnValueChange);
        }
        #endregion

        #region Public Methods
        public void SetSliderText(string text) => _text.text = text;
        public void SetSliderValue(float value) => _slider.value = value;
        #endregion
        
        #region Private Methods
        private void Slider_OnValueChange(float value) => OnSliderValueChangeEvent?.Invoke(value);
        #endregion
    }
}