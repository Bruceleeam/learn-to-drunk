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
        gm.ChangeState(new StartState());
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void InvokeEntering()
    {
        base.InvokeEntering();
        gm.SetCocktail();
        gm.LoadRandomObjectsFromResources();
        gm.DeactiveIngredients();
        gm.UpdateInstruction("Preparati per il prossimo Cocktail!");
    }

    public override void InvokeExiting()
    {
        base.InvokeExiting();
    }

}
