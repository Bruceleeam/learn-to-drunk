using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;
using DesignPatterns.Factory;

public class WrongAnswerState : BaseState
{

    public WrongAnswerState()
    {
    }

    public override void Enter(GameManager owner)
    {
        base.Enter(owner);
    }

    public override void Execute()
    {

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void InvokeEntering()
    {
        gm.OnUpdateUI("Sbagliato!");
        gm.Lifes -= 1;
        gm.GameOver += OnGMGameOver;
        base.InvokeEntering();
    }

    public override void InvokeExiting()
    {
        base.InvokeExiting();
    }

    protected override void OnGMCompleted()
    {
        gm.ChangeState(new StartState());
    }

    private void OnGMGameOver()
    {
        gm.ChangeState(new GameOverState());
    }
}
