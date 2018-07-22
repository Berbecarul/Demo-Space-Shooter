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
        public GameObject startHint;

		 
        private void OnEnable()
        {
			Events._onPlayerHpUpdate += Events__onPlayerHpUpdate;
			Events._onScoreUpdate += Events__onScoreUpdate;
            Events._onWaveStarted += Events__onWaveStarted;
        }

		private void Events__onWaveStarted()
        {
            if (startHint == null)
                return;
             
            startHint.gameObject.SetActive(false);
        }
 

		private void Events__onScoreUpdate(int obj)
        {
            if (scoreText == null)
                return;
            scoreText.text = "Score:" + obj.ToString();
        }

		private void Events__onPlayerHpUpdate(int obj)
        {
            if (scoreText == null)
                return;
			playerHpText.text = "Lives:" +obj.ToString();
        }

        private void OnDisable()
		{
			Events._onPlayerHpUpdate -= Events__onPlayerHpUpdate;
			Events._onScoreUpdate -= Events__onScoreUpdate;
			Events._onWaveStarted -= Events__onWaveStarted;
		}


    }

}