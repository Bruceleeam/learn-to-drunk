using UnityEngine;
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

        gm._task.text = "Realizza un " + gm._cocktail.name;
    }

    public override void Execute()
	{
		gm.ChangeState(new StartState()); 
    }

    public override void Exit()
    {
        Debug.Log("Exit Intro State");
    }

}
