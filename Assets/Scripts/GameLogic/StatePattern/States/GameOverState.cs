﻿using UnityEngine;
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
        gm.UpdateGameData();
        SceneManager.LoadScene("Menu");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void InvokeEntering()
    {
        base.InvokeEntering();
        gm.Next();
        gm.UpdateDialog("Game Over");
    }

    public override void InvokeExiting()
    {
        base.InvokeExiting();
    }

}
