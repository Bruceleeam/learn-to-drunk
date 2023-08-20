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
        gm.OnDeactiveDrag();
    }

    public override void Execute()
	{
        gm.ChangeState(new StartState());
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void InvokeEntering()
    {
        gm._cocktail = gm._creator.GetComponent<Creator>().GetProduct(StaticGameData._gameData._lastTown);
        GameManager._userIngredients.Clear();
        gm.OnInitSVChoices();
        gm.OnUpdateUI("Preparati per il prossimo Cocktail!");
        base.InvokeEntering();
    }

    public override void InvokeExiting()
    {
        base.InvokeExiting();
    }

}
