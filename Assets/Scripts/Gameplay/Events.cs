using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Events
{

    /// <summary>
    /// Event called after the scenes was activated and objects are instanced
    /// </summary>
    public static event Action _onLevelLoadedAndReady;
    public static void InvokeLevelLoadedAndReady()
    {
        _onLevelLoadedAndReady?.Invoke();

    }

    public static event Action _onLoadingSeqStart;
    public static void InvokeLoadingSeqStart()
    {
        _onLoadingSeqStart?.Invoke();
    }

    public static event Action _onLoadingScreenActivated;
    public static void InvokeScreenActivated()
    {
        _onLoadingScreenActivated?.Invoke();
    }

    public static event Action<int> _playerHpUpdate;
    public static void InvokePlayerHpUpdate(int hp)
    {
        _playerHpUpdate.Invoke(hp);

    }

    public static event Action<int> _scoreUpdate;
    public static void InvokeScoreUpdate(int score)
    {
        _scoreUpdate.Invoke(score);
    }

    public static event Action _waveStarted;
    public static void InvokeWaveStarted()
    {
        _waveStarted?.Invoke(); 
    }

    public static event Action _gameOver;
    public static void InvokeGameOver()
    {
        _gameOver?.Invoke();
    }


}
