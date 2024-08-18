using Menus.Common;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Menus.PauseMenu
{
    public class PauseMenuView : MonoBehaviour
    {
        #region Editor Variables
        [Header("Pause Menu View")]
        [Header("References")]
        [SerializeField] private MenuPanel[] _menuPanels = null;
        #endregion

        #region Variables
        public bool viewState => gameObject.activeSelf;
        #endregion

        #region Unity Methods
        private void OnDestroy()
        {
            Deinit();
        }
        #endregion

        #region Callbacks

        #endregion

        #region Public Methods
        public void SetUpCallBacks(int panelIndex, List<Action> callbacks)
        {
            if (!ValidPanelIndexCheck(panelIndex))
            {
                return;
            }

            for (int i = 0; i < callbacks.Count; i++)
            {
                _menuPanels[panelIndex].SubcribeToButtonOnClick(i, callbacks[i]);
            }
        }

        public void SetViewState(bool state)
        {
            gameObject.SetActive(state);
        }

        public void OpenViewPanel(int index)
        {
            if (!ValidPanelIndexCheck(index))
            {
                return;
            }
            
            for (int i = 0; i < _menuPanels.Length; i++)
            {
                if (i == index)
                {
                    _menuPanels[i].SetPanelActiveInHierarchy(true);
                }
                else
                {
                    _menuPanels[i].SetPanelActiveInHierarchy(false);
                }
            }
        }
        #endregion

        #region Private Methods
        private void Deinit()
        {
            foreach (MenuPanel menuPanel in _menuPanels)
            {
                menuPanel.ClearButtonsOnClickEvent();
            }
        }

        private bool ValidPanelIndexCheck(int index)
        {
            return index >= 0 || index < _menuPanels.Length;
        }
        #endregion








    }
}