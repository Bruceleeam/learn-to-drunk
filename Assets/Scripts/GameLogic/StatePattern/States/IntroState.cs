using UnityEngine;
using System.Collections.Generic;
using System;
using DesignPatterns.Factory;
using System.Collections;

public class IntroState : BaseState
{

    public IntroState()
    {
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
        base.Exit();
    }

    public override void InvokeEntering()
    {
        gm._cocktail = gm._creator.GetComponent<Creator>().GetProduct(PlayerPrefs.GetString("LastTown"));
        GameManager._userIngredients.Clear();
        gm.OnInitSVChoices();
        gm.OnPrintMessage("Preparati per il prossimo Cocktail!");
        base.InvokeEntering();
    }

    public override void InvokeExiting()
    {
        base.InvokeExiting();
    }

    protected override void OnGMCompleted()
    {
        gm.ChangeState(new StartState());
    }
}
