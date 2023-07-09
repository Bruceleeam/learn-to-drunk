using UnityEngine;
using System;
abstract public class FSMState <T>
{
    abstract public void OnExiting();
    abstract public void OnEntering();
    abstract public void InvokeEntering();
    abstract public void InvokeExiting();
    abstract public void Enter (T owner);
	abstract public void Execute();
	abstract public void Exit();
}
