using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{

    public class UI_LevelHud : MonoBehaviour
    {
        [Header("References")]
        public Text scoreText; 
        public Text playerHpText;

        private void OnEnable()
        {
            Events._playerHpUpdate += Events__playerHpUpdate;
            Events._scoreUpdate += Events__scoreUpdate;
            
        }

        private void Events__scoreUpdate(int obj)
        {
            if (scoreText == null)
                return;
            scoreText.text = obj.ToString();
        }

        private void Events__playerHpUpdate(int obj)
        {
            if (scoreText == null)
                return;
            playerHpText.text = obj.ToString();
        }

        private void OnDisable()
        {
            Events._playerHpUpdate -= Events__playerHpUpdate;
            Events._scoreUpdate -= Events__scoreUpdate;
        }


    }

}