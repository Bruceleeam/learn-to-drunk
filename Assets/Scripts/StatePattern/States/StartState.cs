﻿using UnityEngine;
using System.Collections.Generic;
using System;

public class StartState : FSMState<GameManager>
{
    GameManager gm;

    public StartState(){
	}

	public override void Enter(GameManager owner)
    {
        Debug.Log("Enter Intro State");
		gm = owner;
    }

    public override void Execute()
	{
		gm.ChangeState(new PlayState()); 
    }

    public override void Exit()
    {
        Debug.Log("Exit Intro State");
    }

}
