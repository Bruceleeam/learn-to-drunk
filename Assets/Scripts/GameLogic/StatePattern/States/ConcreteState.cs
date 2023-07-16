using UnityEngine;
using System.Collections.Generic;
using System;
using DesignPatterns.Factory;

public abstract class BaseState : FSMState<GameManager>
{
    protected GameManager gm;
    public event Action Entering;
    public event Action Exiting;

    public override void OnEntering()
    {
        Entering?.Invoke();
    }
    public override void OnExiting()
    {
        Exiting?.Invoke();
    }

    public BaseState(){
    }

    public override void Enter(GameManager owner)
    {
        Debug.Log("Enter " + this.GetType());
        gm = owner;
        gm.registerSubject(this);
        gm.Completed += OnGMCompleted;
        InvokeEntering();
    }

    public override void Execute()
	{
        
    }

    public override void Exit()
    {
        Debug.Log("Exit Intro State");
    }

    public override void InvokeEntering()
    {
        Debug.Log("Entering " + this.GetType());
        OnEntering();
    }

    public override void InvokeExiting()
    {
        Debug.Log("Exiting " + this.GetType());
        OnExiting();
    }

    protected abstract void OnGMCompleted();
}
