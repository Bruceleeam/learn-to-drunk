using UnityEngine;
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
        Debug.Log("Exit Right Answer State");
    }

    public override void InvokeEntering()
    {
        GameManager.stateMessage = "Esatto!";
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
        gm.ChangeState(new CheckRunState());
    }
}
