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
        Debug.Log("Enter Intro State");
		gm = owner;
    }

    public override void Execute()
	{
		gm.ChangeState(new CheckAnswerState()); 
    }

    public override void Exit()
    {
        Debug.Log("Exit Intro State");
    }

}
