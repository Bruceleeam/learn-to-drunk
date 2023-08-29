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
        if (StaticGameData._gameData._lifes == 0)
            gm.ChangeState(new GameOverState());
        else
            gm.ChangeState(new StartState());
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void InvokeEntering()
    {
        base.InvokeEntering();
        gm.WaitForNext();
        gm.UpdateInstruction("Sbagliato!");
        gm.UpdateLifes(-1);
    }

    public override void InvokeExiting()
    {
        base.InvokeExiting();
    }

}
