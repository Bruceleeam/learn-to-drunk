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
		gm = owner;
    }

    public override void Execute()
	{
        //StartCoroutine("Error");
        if (GameManager._update)
        {
            GameManager._update = false;
            gm.ChangeState(new StartState());
        }
    }

    public override void Exit()
    {
        Debug.Log("Exit Wrong Answer State");
    }

    //IEnumerator Error()
    //{
    //    gm._task.text = "ERROE";
    //    yield return new WaitForSeconds(3);
    //    gm.ChangeState(new StartState()); 
    //}

}
