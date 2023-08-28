using UnityEngine;
using System.Collections.Generic;
using System;
using DesignPatterns.Factory;
using System.Linq;
using System.Collections;

public class CheckAnswerState : BaseState
{

    public CheckAnswerState()
    {
    }

    public override void Enter(GameManager owner)
    {
        base.Enter(owner);
    }

    public override void Execute()
    {
        if (gm.ValidateCocktail())
            gm.ChangeState(new RightAnswerState());
        else
            gm.ChangeState(new WrongAnswerState());
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void InvokeEntering()
    {
        base.InvokeEntering();
        gm.Confirm();
    }

    public override void InvokeExiting()
    {
        base.InvokeExiting();
    }
}
