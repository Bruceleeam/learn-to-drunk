using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

public class WrongAnswerState : FSMState<GameManager>
{
    GameManager gm;

    public WrongAnswerState(){
	}

	public override void Enter(GameManager owner)
    {
        Debug.Log("Enter Wrong Answer State");
        GameManager._update = false;
        GameManager._feedback = true;
        gm = owner;
        gm.DecreaseLife();
    }

    public override void Execute()
	{
        //StartCoroutine("Error");
        if (GameManager._update)
        {
            GameManager._update = false;

            if (gm.GetLife() == 0)
                gm.ChangeState(new GameOverState());
            else
                gm.ChangeState(new StartState());
        }
    }

    public override void Exit()
    {
        Debug.Log("Exit Wrong Answer State");
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

    //IEnumerator Error()
    //{
    //    gm._task.text = "ERROE";
    //    yield return new WaitForSeconds(3);
    //    gm.ChangeState(new StartState()); 
    //}

}
