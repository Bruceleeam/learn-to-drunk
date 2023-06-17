using UnityEngine;
using System.Collections.Generic;
using System;

public class GameOverState : FSMState<GameManager>
{
    GameManager gm;

    public GameOverState(){
	}

	public override void Enter(GameManager owner)
    {
        Debug.Log("Enter Game Over State");
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
