using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{

    public class UI_SceneTransitioner : MonoBehaviour
    {
        [Header("References")]
        public Animator scrBlackenerAnim;

        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);

            Events._onLoadingSeqStart += Events__onLoadingSeqStart;

        }

        private void Events__onLoadingSeqStart()
        {
            scrBlackenerAnim.SetTrigger("Activate");
            Events._onLoadingSeqStart -= Events__onLoadingSeqStart;

            Events._onLevelLoadedAndReady += Events__onLevelLoadedAndReady;
        }

        private void Events__onLevelLoadedAndReady()
        {
            scrBlackenerAnim.SetTrigger("Deactivate");
            Events._onLevelLoadedAndReady -= Events__onLevelLoadedAndReady;
			Events._onLoadingSeqStart += Events__onLoadingSeqStart;
        }

        private void OnDestroy()
        {
			 

        }

        /// <summary>
        /// This is a callback from the animation, and it should not be called otherwise
        /// </summary>  
        public void _OnLoadingScreenActive()
        {
            Events.InvokeScreenActivated();

        }




    }

}