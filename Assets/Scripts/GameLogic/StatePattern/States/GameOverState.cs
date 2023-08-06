using UnityEngine;
using System.Collections.Generic;
using System;
using DesignPatterns.Factory;
using UnityEngine.SceneManagement;

public class GameOverState : BaseState
{

    public GameOverState()
    {
    }

    public override void Enter(GameManager owner)
    {
        base.Enter(owner);
    }

    public override void Execute()
    {
        gm.GetComponent<StorageData>().SaveDataLocally(new GameData());
        StaticGameData._gameData = gm.GetComponent<StorageData>().LoadData();
        SceneManager.LoadScene("Menu");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void InvokeEntering()
    {
        gm.OnUpdateUI("Game Over");
        base.InvokeEntering();
    }

    public override void InvokeExiting()
    {
        base.InvokeExiting();
    }

}
