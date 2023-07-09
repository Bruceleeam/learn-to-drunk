using UnityEngine;
using System.Collections.Generic;
using System;

public class RightAnswerState : FSMState<GameManager>
{
    GameManager gm;

    public RightAnswerState(){
	}

	public override void Enter(GameManager owner)
    {
        Debug.Log("Enter Right Answer State");
        GameManager._update = false;
        GameManager._feedback = true;
        gm = owner;
    }

    public override void Execute()
	{
        if (GameManager._update)
        {
            GameManager._update = false;
            gm.ChangeState(new CardUnlockingState());
        }
    }

    public override void Exit()
    {
        Debug.Log("Exit Right Answer State");
    }

    public override void InvokeEntering()
    {
        throw new NotImplementedException();
    }

    public override void InvokeExiting()
    {
        throw new NotImplementedException();
    }

    public override void OnEntering()
    {
        throw new NotImplementedException();
    }

    public override void OnExiting()
    {
        throw new NotImplementedException();
    }
}
