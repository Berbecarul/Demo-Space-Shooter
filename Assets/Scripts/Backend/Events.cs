using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Gameplay;

public static class Events
{

     
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

	public static event Action<int> _onPlayerHpUpdate;
    public static void InvokePlayerHpUpdate(int hp)
    {
		_onPlayerHpUpdate?.Invoke(hp);

    }

    public static event Action<int> _onScoreUpdate;
    public static void InvokeScoreUpdate(int score)
    {
		_onScoreUpdate?.Invoke(score);
    }

    public static event Action _onWaveStarted;
    public static void InvokeWaveStarted()
    {
		_onWaveStarted?.Invoke(); 
    }

	public static event Action<Enemy> _onEnemyKilled;
	public static void InvokeEnemyKilled(Enemy enemy)
	{
		_onEnemyKilled?.Invoke (enemy);

	}
 
 
}
