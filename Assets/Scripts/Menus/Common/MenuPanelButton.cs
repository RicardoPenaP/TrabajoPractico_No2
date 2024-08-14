using System;
using UnityEngine;
using UnityEngine.UI;

namespace Menus.Common
{
    public class MenuPanelButton : MonoBehaviour
    {
        [Header("Menu Panel Button")]
        [Header("References")]
        [SerializeField] private Button _button = null;

        public event Action OnClickButtonEvent = delegate { };

        private void Awake()
        {
            _button.onClick.AddListener(Button_OnClick);                
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(Button_OnClick);
        }

        public void ClearOnClickEvent() => OnClickButtonEvent = delegate { };

        private void Button_OnClick() => OnClickButtonEvent?.Invoke(); 
        
    }

}
