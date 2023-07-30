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
        if (gm.Lifes == 0)
            gm.ChangeState(new GameOverState());
        else
            gm.ChangeState(new StartState());
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void InvokeEntering()
    {
        gm.OnUpdateUI("Sbagliato!");
        gm.Lifes -= 1;
        base.InvokeEntering();
    }

    public override void InvokeExiting()
    {
        base.InvokeExiting();
    }

}
