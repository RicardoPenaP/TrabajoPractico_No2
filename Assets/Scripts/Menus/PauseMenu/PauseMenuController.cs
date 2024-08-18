using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Menus.PauseMenu
{
    public enum PauseMenuPanels
    {
        Main,
        Settings,
        Credits
    }
    public class PauseMenuController : MonoBehaviour
    {
        #region Editor Variables
        [Header("Pause Menu Controller")]
        [Header("References")]
        [SerializeField] private PauseMenuView _menuView = null;
        [SerializeField] private PauseMenuModel _menuModel = null;
        #endregion

        #region Variables

        #endregion

        #region Unity Methods
        private void Awake()
        {
            Init();
        }

        private void Update()
        {
            GetKeyboardInput();
        }

        private void OnDestroy()
        {
            Deinit();
        }
        #endregion

        #region Callbacks
        private void MenuModel_OnPauseStatusChange(bool state)
        {
            _menuView.SetViewState(state);
        }

        #endregion

        #region Private Methods
        private void Init()
        {
            _menuModel.OnPauseStatusChange += MenuModel_OnPauseStatusChange;
            List<Action> mainPanelButtonsActions = new List<Action>();

            mainPanelButtonsActions.Add(TogglePause);
            mainPanelButtonsActions.Add(OpenSettingsPanel);

            _menuView.SetUpCallBacks((int)PauseMenuPanels.Main, mainPanelButtonsActions);
        }

        private void Deinit()
        {
            _menuModel.OnPauseStatusChange -= MenuModel_OnPauseStatusChange;
        }

        private void GetKeyboardInput()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();
            }
        }

        private void TogglePause()
        {
            _menuModel.SetIsPaused(!_menuModel.isPaused);
        }

        private void OpenSettingsPanel()
        {
            _menuView.OpenViewPanel((int)PauseMenuPanels.Settings);
        }
        #endregion


    }
}

