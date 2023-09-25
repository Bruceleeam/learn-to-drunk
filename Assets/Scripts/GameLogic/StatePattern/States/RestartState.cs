﻿using UnityEngine;
using System.Collections.Generic;
using System;
using DesignPatterns.Factory;

public class RestartState : BaseState
{

    public RestartState()
    {
    }

    public override void Enter(GameManager owner)
    {
        base.Enter(owner);
    }

    public override void Execute()
    {
        gm.ChangeState(new PlayState());
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void InvokeEntering()
    {
        base.InvokeEntering();
        gm.Next();
        gm.UpdateDialog("Try again!");
    }

    public override void InvokeExiting()
    {
        base.InvokeExiting();
    }

}
