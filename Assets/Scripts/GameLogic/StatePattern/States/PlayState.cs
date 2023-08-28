﻿using UnityEngine;
using System.Collections.Generic;
using System;
using DesignPatterns.Factory;

public class PlayState : BaseState
{

    public PlayState()
    {
    }

    public override void Enter(GameManager owner)
    {
        base.Enter(owner);
    }

    public override void Execute()
    {
        gm.ChangeState(new CheckAnswerState());
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void InvokeEntering()
    {
        base.InvokeEntering();
        gm.ActiveIngredients();
    }

    public override void InvokeExiting()
    {
        base.InvokeExiting();
        gm.DeactiveIngredients();
    }

}
