﻿using UnityEngine;
using System.Collections.Generic;
using System;

public class IntroState : FSMState<GameManager>
{
    GameManager gm;

    public IntroState(){
	}

	public override void Enter(GameManager owner)
    {
        Debug.Log("Enter Intro State");
        gm = owner;
    }

    public override void Execute()
	{
        gm._cocktail = gm._cocktails[new System.Random().Next(0, gm._cocktails.Count)];

        gm.ChangeState(new StartState()); 
    }

    public override void Exit()
    {
        Debug.Log("Exit Intro State");
    }

}
