using System;
using System.Collections.Generic;
using UnityEngine;

namespace Menus.PauseMenu
{
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

            _menuView.SetUpCallBacks(0, mainPanelButtonsActions);
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
        #endregion


    }
}

