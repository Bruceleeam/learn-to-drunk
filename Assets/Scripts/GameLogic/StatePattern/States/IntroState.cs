using UnityEngine;
using System.Collections.Generic;
using System;
using DesignPatterns.Factory;

public class IntroState : FSMState<GameManager>
{
    GameManager gm;

    public IntroState(){
    }

    public override void Enter(GameManager owner)
    {
        Debug.Log("Enter Intro State");
        GameManager._update = false;
        GameManager._feedback = true;
        gm = owner;
        gm._cocktail = gm._creator.GetComponent<Creator>().GetProduct();
    }

    public override void Execute()
	{
        if (GameManager._update)
        {
            //gm._cocktail = gm._cocktails[new System.Random().Next(0, gm._cocktails.Count)];
            //// API?
            //CocktailUnlocking();
            //gm._cocktails.Remove(gm._cocktail);
            gm.ChangeState(new StartState());
        }
    }

    public override void Exit()
    {
        Debug.Log("Exit Intro State");
    }

    public void CocktailUnlocking()
    {
        //if (PlayerPrefs.HasKey(gm._cocktail.name) && PlayerPrefs.GetInt(gm._cocktail.name) == 1)
        //    gm._cocktail.SetCardUnlocked(true);
        //else
        //    gm._cocktail.SetCardUnlocked(false);
    }

}
