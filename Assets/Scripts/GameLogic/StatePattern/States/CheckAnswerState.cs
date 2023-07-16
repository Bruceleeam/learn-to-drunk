using UnityEngine;
using System.Collections.Generic;
using System;
using DesignPatterns.Factory;
using System.Linq;

public class CheckAnswerState : FSMState<GameManager>
{
    GameManager gm;

    public CheckAnswerState(){
	}

	public override void Enter(GameManager owner)
    {
        Debug.Log("Enter Check Answer State");
		gm = owner;
    }

    public override void Execute()
	{
        if (Compare(gm._userIngredients, gm._cocktail))
        {
            foreach (string ui in gm._userIngredients)
            {
                Debug.Log("ui:" + ui);
            }
            gm.ChangeState(new RightAnswerState());
        }
        else
        {
            foreach (string ui in gm._userIngredients)
            {
                Debug.Log("ui:" + ui);
            }
            gm.ChangeState(new WrongAnswerState());
        }
    }

    public override void Exit()
    {
        Debug.Log("Exit Check Answer State");
    }

    public override void InvokeEntering()
    {
        throw new NotImplementedException();
    }

    public override void InvokeExiting()
    {
        throw new NotImplementedException();
    }

    public override void OnEntering()
    {
        throw new NotImplementedException();
    }

    public override void OnExiting()
    {
        throw new NotImplementedException();
    }

    bool Compare(List<String> userIngredients, IProduct p)
    {

        foreach(string ui in userIngredients)
        {
            Debug.Log("ui:" + ui);
        }

        bool temp = false;

        foreach (GameObject ing in p.Ingredients)
        {
            if (userIngredients.Contains(ing.name))
                temp = true;
            else
                return false;
        }

        return temp;
    }

}
