using System;
using UnityEngine;

namespace Menus.Common
{
    public class MenuPanel : MonoBehaviour
    {
        [Header("Menu Panel")]
        [Header("References")]
        [SerializeField] private MenuPanelButton[] _panelButtons = null;

        public void SubcribeToButtonOnClick(int buttonIndex, Action callback)
        {
            if (!ValidButtonIndexCheck(buttonIndex))
            {
                return;
            }

            _panelButtons[buttonIndex].OnClickButtonEvent += callback;
        }

        public void UnSubcribeToButtonOnClick(int buttonIndex, Action callback)
        {
            if (!ValidButtonIndexCheck(buttonIndex))
            {
                return;
            }

            _panelButtons[buttonIndex].OnClickButtonEvent -= callback;
        }
        
        public void ClearButtonsOnClickEvent()
        {
            foreach (MenuPanelButton panelButtons in _panelButtons)
            {
                panelButtons.ClearOnClickEvent();
            }
        }

        private bool ValidButtonIndexCheck(int index)
        {
            return index >= 0 || index < _panelButtons.Length;           
        }

    }
}

