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
        gm.GetComponent<StorageData>().SaveDataLocally(StaticGameData._gameData);
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
