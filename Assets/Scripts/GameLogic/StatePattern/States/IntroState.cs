using UnityEngine;
using System.Collections.Generic;
using System;
using DesignPatterns.Factory;

public class IntroState : ConcreteState
{

    public IntroState(){
    }

    public override void Enter(GameManager owner)
    {
        base.Enter(owner);
    }

    public override void Execute()
	{
        
    }

    public override void Exit()
    {
        Debug.Log("Exit Intro State");
    }

    public override void InvokeEntering()
    {
        Debug.Log("Intro State ENTERING");
        GameManager.stateMessage = "Preparati per il prossimo Cocktail!";
        gm._cocktail = gm._creator.GetComponent<Creator>().GetProduct();
        OnEntering();
    }

    public new void InvokeExiting()
    {
        base.InvokeExiting();
    }

    private void OnGMCompleted()
    {
        gm.ChangeState(new StartState());
    }

    //public void CocktailUnlocking()
    //{
    //    if (PlayerPrefs.HasKey(gm._cocktail.name) && PlayerPrefs.GetInt(gm._cocktail.name) == 1)
    //        gm._cocktail.SetCardUnlocked(true);
    //    else
    //        gm._cocktail.SetCardUnlocked(false);
    //}

}
