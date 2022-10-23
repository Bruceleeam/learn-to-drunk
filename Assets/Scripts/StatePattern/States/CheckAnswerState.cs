﻿using UnityEngine;
using System.Collections.Generic;
using System;

public class CheckAnswerState : FSMState<GameManager>
{
    GameManager gm;

    public CheckAnswerState(){
	}

	public override void Enter(GameManager owner)
    {
        Debug.Log("Enter Intro State");
		gm = owner;
    }

    public override void Execute()
	{
		gm.ChangeState(new EndState()); 
    }

    public override void Exit()
    {
        Debug.Log("Exit Intro State");
    }

}
