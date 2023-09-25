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
        if (gm.CheckLifes())
            gm.ChangeState(new RestartState());
        else
            gm.ChangeState(new GameOverState());
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void InvokeEntering()
    {
        base.InvokeEntering();
        gm.Next();
        gm.UpdateDialog("Oops, that's not it");
        gm.UpdateLifes(-1);
    }

    public override void InvokeExiting()
    {
        base.InvokeExiting();
    }

}
