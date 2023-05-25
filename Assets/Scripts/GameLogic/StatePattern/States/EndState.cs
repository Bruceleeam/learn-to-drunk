using UnityEngine;
using System.Collections.Generic;
using System;

public class EndState : FSMState<GameManager>
{
    GameManager gm;

    public EndState(){
	}

	public override void Enter(GameManager owner)
    {
        Debug.Log("Enter End State");
        GameManager._feedback = true;
		gm = owner;
    }

    public override void Execute()
	{
		//gm.ChangeState(new PlayState()); 
    }

    public override void Exit()
    {
        Debug.Log("Exit End State");
    }

}
