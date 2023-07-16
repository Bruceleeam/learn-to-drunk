using UnityEngine;
using System.Collections.Generic;
using System;
using DesignPatterns.Factory;

public class IntroState : BaseState
{

    public IntroState()
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
        Debug.Log("Exit Intro State");
    }

    public override void InvokeEntering()
    {
        GameManager.stateMessage = "Preparati per il prossimo Cocktail!";
        GameManager.spriteCode = 0;
        gm._cocktail = gm._creator.GetComponent<Creator>().GetProduct();
        OnEntering();
    }

    public new void InvokeExiting()
    {
        base.InvokeExiting();
    }

    protected override void OnGMCompleted()
    {
        gm.ChangeState(new StartState());
    }
}
