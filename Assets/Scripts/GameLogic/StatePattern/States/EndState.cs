using UnityEngine;
using System.Collections.Generic;
using System;
using DesignPatterns.Factory;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class EndState : BaseState
{

    public EndState(){
	}

	public override void Enter(GameManager owner)
    {
        base.Enter(owner);
    }

    public override void Execute()
	{
        _gameData._lastTown = PlayerPrefs.GetString("LastTown");
        _gameData._lifes = gm.Lifes;
        gm.GetComponent<StorageData>().SaveDataLocally(_gameData);
        StaticGameData._gameData = gm.GetComponent<StorageData>().LoadData();
        SceneManager.LoadScene("Map");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void InvokeEntering()
    {
        gm.OnUpdateUI("Si beve!");
        base.InvokeEntering();
    }

    public override void InvokeExiting()
    {
        base.InvokeExiting();
    }

}
