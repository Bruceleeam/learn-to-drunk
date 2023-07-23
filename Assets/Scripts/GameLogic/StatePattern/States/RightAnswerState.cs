﻿using UnityEngine;
using System.Collections.Generic;
using System;
using DesignPatterns.Factory;

public class RightAnswerState : BaseState
{

    public RightAnswerState()
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
        gm.OnPrintMessage("Esatto!");
        base.InvokeEntering();
    }

    public override void InvokeExiting()
    {
        base.InvokeExiting();
    }

    protected override void OnGMCompleted()
    {
        gm.ChangeState(new CardUnlockingState());
    }
}
