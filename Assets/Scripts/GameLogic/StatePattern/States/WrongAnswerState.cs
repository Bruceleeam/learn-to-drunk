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

    }

    public override void Exit()
    {
        Debug.Log("Exit Wrong Answer State");
    }

    public override void InvokeEntering()
    {
        GameManager.stateMessage = "Sbagliato!";
        GameManager.spriteCode = 0;
        gm._cocktail = gm._creator.GetComponent<Creator>().GetProduct();
        OnEntering();
    }

    public override void InvokeExiting()
    {
        base.InvokeExiting();
    }

    protected override void OnGMCompleted()
    {
        gm.ChangeState(new StartState());
    }
}
