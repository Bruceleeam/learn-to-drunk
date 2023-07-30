﻿using UnityEngine;
using System.Collections.Generic;
using System;
using DesignPatterns.Factory;

public class CardUnlockingState : BaseState
{

    public CardUnlockingState(){
	}

	public override void Enter(GameManager owner)
    {
        base.Enter(owner);
    }

    public override void Execute()
	{
        gm.ChangeState(new EndState());
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void InvokeEntering()
    {
        base.InvokeEntering();
        if (!PlayerPrefs.HasKey(gm._cocktail.ProductName))
        {
            GameManager._cardUnlocking = true;
            gm.OnUpdateUI("Complimenti! Hai sbloccato una nuova card");
        }
    }

    public override void InvokeExiting()
    {
        base.InvokeExiting();
    }

}
