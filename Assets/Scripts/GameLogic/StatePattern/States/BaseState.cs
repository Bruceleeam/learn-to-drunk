using UnityEngine;
using System.Collections.Generic;
using System;
using DesignPatterns.Factory;

public abstract class BaseState : FSMState<GameManager>
{
    protected GameManager gm;
    protected GameData _gameData = new GameData();

    public BaseState(){
    }

    public override void Enter(GameManager owner)
    {
        Debug.Log("Enter " + this.GetType());
        gm = owner;
        gm._next = false;
        InvokeEntering();
    }

    public override void Execute()
	{
        
    }

    public override void Exit()
    {
        Debug.Log("Exit " + this.GetType());
        InvokeExiting();
    }

    public override void InvokeEntering()
    {
        Debug.Log("Entering " + this.GetType());
    }

    public override void InvokeExiting()
    {
        Debug.Log("Exiting " + this.GetType());
    }

}
