using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

namespace BackEnd
{

    public class GameManager : MonoBehaviour
    {
        public static GameManager _instance { get; protected set; }

        public static bool _gameIsPaused
        {
            get
            {
                return paused;
            }
            set
            {
                paused = value;
                Time.timeScale = paused ? 0 : 1;
            }
        }

        [Header("Scene Management")]
        public string firstLoad = "Level00";

        static bool isLoading = false;
        static int nextSceneIndexToLoad;
        static bool paused = false;


        private void Awake()
        {
            if (_instance == null)
                _instance = this;
            else
                Destroy(this);

            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            LoadNextLevel();
        }

        public static void ExitGame()
        {
            Application.Quit();
        }

        #region LEVEL_MANAGEMENT

        public static void QuickLoadLevel(int index)
        {

        }

        public static void LoadNextLevel()
        {
            LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public static void RestartLevel()
        {
            LoadLevel(SceneManager.GetActiveScene().buildIndex);
        }

        public static void LoadLevel(string name)
        {
            if (isLoading)
            {
                Debug.LogWarning("A secene is already loading");
                return;
            }

            //prepare
            nextSceneIndexToLoad  = SceneManager.GetSceneByName(name).buildIndex ;
            Events._onLoadingScreenActivated += Events__onLoadingScreenBlackened;

            //trigger the loading seq
            Events.InvokeLoadingSeqStart();
        }
         

        public static void LoadLevel(int index)
        {
            if ( isLoading)
            {
                Debug.LogWarning("A secene is already loading");
                return;
            }

            //prepare
            nextSceneIndexToLoad =  index;
            Events._onLoadingScreenActivated += Events__onLoadingScreenBlackened;

            //trigger the loading seq
            Events.InvokeLoadingSeqStart();
        }

        private static void Events__onLoadingScreenBlackened()
        {
            //unsub
            Events._onLoadingScreenActivated -= Events__onLoadingScreenBlackened;

            //load the scene
            SceneManager.LoadSceneAsync(nextSceneIndexToLoad, LoadSceneMode.Single).allowSceneActivation = true;
            SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;

            //wait for the scene to load
        }

        private static void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
        {
            //unsub
            SceneManager.activeSceneChanged -= SceneManager_activeSceneChanged;

            Debug.Log(arg1.name + " Has Loaded");
            isLoading = false;

            _gameIsPaused = false;
            Events.InvokeLevelLoadedAndReady();
           
        }

        

        #endregion
    }

}