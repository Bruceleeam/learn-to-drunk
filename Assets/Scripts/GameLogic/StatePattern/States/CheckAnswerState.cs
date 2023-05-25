using UnityEngine;
using System.Collections.Generic;
using System;

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

        if (Compare(gm._user_cocktail, gm._cocktail))
        {
            gm._task.text = "Esatto!!";
            gm.ChangeState(new RightAnswerState());
        }
        else
        {
            gm._task.text = "Hai sbagliato!";
            gm.ChangeState(new WrongAnswerState());
        }
        GameManager._feedback = true;
    }

    public override void Exit()
    {
        Debug.Log("Exit Check Answer State");
    }

    bool Compare(Cocktail a, Cocktail b)
    {
        Debug.Log(JsonUtility.ToJson(a).ToString());
        Debug.Log(JsonUtility.ToJson(b).ToString());
        if (a._base == b._base && a._flavoring == b._flavoring && a._dye == b._dye && a._decoration == b._decoration)
            return true;

        return false;
    }

}
