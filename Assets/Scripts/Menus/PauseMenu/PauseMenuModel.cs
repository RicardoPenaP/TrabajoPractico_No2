﻿using System;
using UnityEngine;

namespace Menus.PauseMenu
{
    public class PauseMenuModel : MonoBehaviour
    {
        public event Action<bool> OnPauseStatusChange = delegate { };

        private bool _isPaused = false;
        public bool isPaused => _isPaused;

        public void SetIsPaused(bool state)
        {
            _isPaused = state;
            Time.timeScale = _isPaused ? 0f : 1f;
            OnPauseStatusChange?.Invoke(_isPaused);
        }

    }
}