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
        if (Compare(GameManager._userIngredients, gm._cocktail))
            gm.ChangeState(new RightAnswerState());
        else
            gm.ChangeState(new WrongAnswerState());
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void InvokeEntering()
    {
        base.InvokeEntering();
        gm.Confirm();
    }

    public override void InvokeExiting()
    {
        base.InvokeExiting();
    }

    bool Compare(List<GameObject> userIngredients, IProduct p)
    {
        List<string> tempIngredients1 = userIngredients.Select(obj => obj.name).ToList();
        List<string> tempIngredients2 = p.Ingredients.Select(obj => obj.name).ToList();

        if (tempIngredients2.Count == tempIngredients1.Count && tempIngredients2.All(item => tempIngredients1.Contains(item)))
            return true;
        else
            return false;
        
    }

}
