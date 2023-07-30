﻿using UnityEngine;
using System.Collections.Generic;
using System;
using DesignPatterns.Factory;

public class StartState : BaseState
{

    public StartState()
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
        gm.OnUpdateUI(gm._cocktail.ProductName);
        base.InvokeEntering();
    }

    public override void InvokeExiting()
    {
        base.InvokeExiting();
    }

}
