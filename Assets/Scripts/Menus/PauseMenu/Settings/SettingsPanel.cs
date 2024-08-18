using System;
using Gameplay.Entities.Common.Actions.Movement;
using Menus.Common;
using Unity.VisualScripting;
using UnityEngine;

namespace Menus.PauseMenu.Settings
{
    public class SettingsPanel : MenuPanel
    {
        #region Editor Variables

        [Header("Settings Panel")]
        [Header("References")]
        [SerializeField] private SliderWithText _player1SliderWithText = null;
        [SerializeField] private SliderWithText _player2SliderWithText = null;
        [SerializeField] private MovementSettings _player1MovementSettings = null;
        [SerializeField] private MovementSettings _player2MovementSettings = null;
        #endregion

        #region Unity Methods

        private void Awake()
        {
           Init();
        }

        private void OnDestroy()
        {
            Deinit();
        }
        #endregion

        #region PrivateMethods

        private void Init()
        {
            _player1SliderWithText.SetSliderValue(_player1MovementSettings.normalizedMovementSpeed);
            SetPlayerSettingsInfo(_player1MovementSettings, _player1SliderWithText, 1);
            
            _player2SliderWithText.SetSliderValue(_player2MovementSettings.normalizedMovementSpeed);
            SetPlayerSettingsInfo(_player2MovementSettings, _player2SliderWithText, 2);
            
            _player1SliderWithText.OnSliderValueChangeEvent += OnPlayer1SliderValueChange;
            _player2SliderWithText.OnSliderValueChangeEvent += OnPlayer2SliderValueChange;
           
        }

        private void Deinit()
        {
            _player1SliderWithText.OnSliderValueChangeEvent += OnPlayer1SliderValueChange;
            _player2SliderWithText.OnSliderValueChangeEvent += OnPlayer2SliderValueChange;
        }
        
        private void OnPlayer1SliderValueChange(float value)
        {
            _player1MovementSettings.SetNormalizedMovementSpeed(value);
            SetPlayerSettingsInfo(_player1MovementSettings, _player1SliderWithText, 1);
        }
        
        private void OnPlayer2SliderValueChange(float value)
        {
            _player2MovementSettings.SetNormalizedMovementSpeed(value);
            SetPlayerSettingsInfo(_player2MovementSettings, _player2SliderWithText, 2);
        }

        private void SetPlayerSettingsInfo(MovementSettings playerMovementSettings, SliderWithText sliderWithText , int playerIndex)
        {
            sliderWithText.SetSliderText($"Player {playerIndex} movement speed: {playerMovementSettings.movementSpeed.ToString("F2")}");
        }

        #endregion
    }
}