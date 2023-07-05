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

            gm._task.text = "Esatto!!";
            gm.ChangeState(new RightAnswerState());
        }
        else
        {
            gm._task.text = "Hai sbagliato!";
            gm.ChangeState(new WrongAnswerState());
        }
    }

    public override void Exit()
    {
        Debug.Log("Exit Check Answer State");
    }

    bool Compare(List<String> userIngredients, IProduct b)
    {
        bool temp = false;

        foreach(GameObject bs in b.Bases)
        {
            if (userIngredients.Contains(bs.name))
                temp = true;
            else
                return false;
        }

        foreach (GameObject fl in b.Flavorings)
        {
            if (userIngredients.Contains(fl.name))
                temp = true;
            else
                return false;
        }

        return true;
    }

}
