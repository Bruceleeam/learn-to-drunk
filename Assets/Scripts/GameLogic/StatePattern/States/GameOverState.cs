using UnityEngine;
using System.Collections.Generic;
using System;
using DesignPatterns.Factory;
using UnityEngine.SceneManagement;

public class GameOverState : BaseState
{
    DataManager _dataManager;
    DataObject _gameData;

    public GameOverState()
    {
    }

    public override void Enter(GameManager owner)
    {
        base.Enter(owner);
    }

    public override void Execute()
    {
        _gameData._lastTown = PlayerPrefs.GetString("LastTown");
        _gameData._lifes = gm.Lifes;
        _dataManager.SaveData(_gameData);
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
