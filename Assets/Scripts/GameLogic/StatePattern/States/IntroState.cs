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

        foreach (Cocktail ck in Resources.LoadAll("Cocktail", typeof(Cocktail)))
            gm._cocktails.Add(ck);

        gm._cocktail = gm._cocktails[new System.Random().Next(0, gm._cocktails.Count)];

        gm._user_cocktail = new Cocktail();

        gm._task.text = "Prepara un " + gm._cocktail.name;
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
