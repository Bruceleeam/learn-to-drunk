using UnityEngine;
using System.Collections.Generic;
using System;

public class CheckRunState : FSMState<GameManager>
{
    GameManager gm;

    public CheckRunState(){
	}

	public override void Enter(GameManager owner)
    {
        Debug.Log("Enter Check Run State");
		gm = owner;
    }

    public override void Execute()
	{
        if(gm._cocktails.Count == 0)
            gm.ChangeState(new EndState());
        else
            gm.ChangeState(new IntroState());
    }

    public override void Exit()
    {
        Debug.Log("Exit Check Run State");
    }

}
