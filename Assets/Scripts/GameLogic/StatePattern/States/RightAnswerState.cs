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
		gm = owner;
    }

    public override void Execute()
	{
		gm.ChangeState(new IntroState()); 
    }

    public override void Exit()
    {
        Debug.Log("Exit Right Answer State");
    }

}
