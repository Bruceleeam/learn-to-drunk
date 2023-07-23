using UnityEngine;
using System.Collections.Generic;
using System;
using DesignPatterns.Factory;
using System.Linq;
using System.Collections;

public class CheckAnswerState : BaseState
{

    public CheckAnswerState()
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
        base.InvokeEntering();
        gm.OnCompleted();
    }

    public override void InvokeExiting()
    {
        base.InvokeExiting();
    }

    protected override void OnGMCompleted()
    {
        if (Compare(GameManager._userIngredients, gm._cocktail))
            gm.ChangeState(new RightAnswerState());
        else
            gm.ChangeState(new WrongAnswerState());
    }

    bool Compare(List<GameObject> userIngredients, IProduct p)
    {
        List<string> tempIngredients1 = userIngredients.Select(obj => obj.name).ToList();
        List<string> tempIngredients2 = p.Ingredients.Select(obj => obj.name).ToList();

        if (tempIngredients2.All(item => tempIngredients1.Contains(item)))
            return true;
        else
            return false;
        
    }

}
