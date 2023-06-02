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
        gm = owner;
        if (PlayerPrefs.HasKey(gm._cocktail.name))
        {
            // ??
            //if (PlayerPrefs.GetInt(gm._cocktail.name) == 0)
            //if (PlayerPrefs.GetInt(gm._cocktail.name) == 1)
            GameManager._update = true;
        }
        else
        {
            PlayerPrefs.SetInt(gm._cocktail.name, 1);
            GameManager._cardUnlocking = true;
        }
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
