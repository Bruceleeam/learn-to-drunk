using UnityEngine;
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
        gm.ChangeState(new ShowCardState());
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void InvokeEntering()
    {
        base.InvokeEntering();
        if (!gm.CheckCard())
        {
            gm.UnlockCard();
            gm.Next();
            gm.UpdateDialog("Congratulations! You've just unlocked a new card.");
        }
        else
        {
            gm.Next(0);
        }
    }

    public override void InvokeExiting()
    {
        base.InvokeExiting();
    }

}
