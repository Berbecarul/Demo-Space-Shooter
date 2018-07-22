using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;

namespace UI
{

    public class UI_PauseMenu : UI_MenuElement
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            GameManager._gameIsPaused = true;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            GameManager._gameIsPaused = false;
        }

        public void _RestartLevelBtn()
        {
            GameManager.RestartLevel();
        }

        public void _ExitGameBtn()
        {
            GameManager.ExitGame();
        }
    }



}