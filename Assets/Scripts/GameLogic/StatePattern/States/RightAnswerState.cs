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
        gm.ChangeState(new CardUnlockingState());
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void InvokeEntering()
    {
        base.InvokeEntering();
        gm.Next();
        gm.UpdateInstruction("You got it!");
    }

    public override void InvokeExiting()
    {
        base.InvokeExiting();
    }

}
