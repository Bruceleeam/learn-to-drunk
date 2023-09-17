using UnityEngine;
using System.Collections.Generic;
using System;
using DesignPatterns.Factory;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class EndState : BaseState
{

    public EndState(){
	}

	public override void Enter(GameManager owner)
    {
        base.Enter(owner);
    }

    public override void Execute()
	{
        gm.UpdateGameData();
        SceneManager.LoadScene("Map");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void InvokeEntering()
    {
        base.InvokeEntering();
        gm.Next();
        gm.UpdateInstruction("Now you know what you're drinking if you select a " + gm._cocktail.Name + ". \n Let's head to the next country to learn a new cocktail! \n LET'S GO!!!");
    }

    public override void InvokeExiting()
    {
        base.InvokeExiting();
    }

}
