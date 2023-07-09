﻿using UnityEngine;
using System.Collections.Generic;
using System;

public class PlayState : FSMState<GameManager>
{
    GameManager gm;

    public PlayState(){
	}

	public override void Enter(GameManager owner)
    {
        Debug.Log("Enter Play State");
        GameManager._feedback = true;

        GameManager.confirm = false;
        gm = owner;

    }

    public override void Execute()
	{
        if(GameManager.confirm)
		    gm.ChangeState(new CheckAnswerState()); 
    }

    public override void Exit()
    {
        Debug.Log("Exit Play State");
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
