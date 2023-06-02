using UnityEngine;
using System.Collections.Generic;
using System;

public class CardUnlockingState : FSMState<GameManager>
{
    GameManager gm;

    public CardUnlockingState(){
	}

	public override void Enter(GameManager owner)
    {
        Debug.Log("Enter Card Unlocking State");
        GameManager._update = false;
        GameManager._cardUnlocking = true;
		gm = owner;
    }

    public override void Execute()
	{
        if (GameManager._update)
        {
            GameManager._update = false;
            gm.ChangeState(new CheckRunState());
        }
    }

    public override void Exit()
    {
        Debug.Log("Exit Card Unlocking State");
    }

}
