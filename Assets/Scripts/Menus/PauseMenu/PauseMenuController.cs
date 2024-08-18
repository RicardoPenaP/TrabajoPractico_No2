using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
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
        #region Static Variables
        private static PauseMenuController _instance = null;
        public static PauseMenuController instance => _instance;
        #endregion
        
        #region Editor Variables
        [Header("Pause Menu Controller")]
        [Header("References")]
        [SerializeField] private PauseMenuView _menuView = null;
        [SerializeField] private PauseMenuModel _menuModel = null;
        #endregion

        #region Variables

        public bool isPaused => _menuModel.isPaused;
        #endregion

        #region Unity Methods
        private void Awake()
        {
            if (_instance is not null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                _instance = this;
            }
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
            if (state)
            {
                _menuView.OpenViewPanel((int)PauseMenuPanels.Main);
            }
            _menuView.SetViewState(state);
            
        }

        #endregion

        #region Private Methods
        private void Init()
        {
            _menuModel.OnPauseStatusChange += MenuModel_OnPauseStatusChange;
            
            // Main Panel setup
            List<Action> mainPanelButtonsActions = new List<Action>();
            mainPanelButtonsActions.Add(MainPanel_PlayButton);
            mainPanelButtonsActions.Add(MainPanel_SettingsButton);
            mainPanelButtonsActions.Add(MainPanel_CreditsButton);
            mainPanelButtonsActions.Add(MainPanel_ExitButton);
            _menuView.SetUpCallBacks((int)PauseMenuPanels.Main, mainPanelButtonsActions);
            
            // Settings Panel setup
            List<Action> settingsPanelButtonActions = new List<Action>();
            settingsPanelButtonActions.Add(SettingsPanel_BackButton);
            _menuView.SetUpCallBacks((int)PauseMenuPanels.Settings, settingsPanelButtonActions);
            
            // Credits Panel setup
            List<Action> creditsPanelButtonActions = new List<Action>();
            creditsPanelButtonActions.Add(CreditsPanel_BackButton);
            _menuView.SetUpCallBacks((int)PauseMenuPanels.Credits, settingsPanelButtonActions);

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
        
        // Main Panel buttons actions
        private void MainPanel_PlayButton()
        {
            TogglePause();
        }
        
        private void MainPanel_SettingsButton()
        {
            _menuView.OpenViewPanel((int)PauseMenuPanels.Settings);
        }

        private void MainPanel_CreditsButton()
        {
            _menuView.OpenViewPanel((int)PauseMenuPanels.Credits);
        }

        private void MainPanel_ExitButton()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
              Application.Quit();
#endif
        }
        
        // Settings Panel buttons actions
        private void SettingsPanel_BackButton()
        {
            _menuView.OpenViewPanel((int)PauseMenuPanels.Main);
        }
        
        // Credits Panel buttons actions
        private void CreditsPanel_BackButton()
        {
            _menuView.OpenViewPanel((int)PauseMenuPanels.Main);
        }
        #endregion


    }
}

