using UnityEngine;

abstract public class FSMState  <T> : MonoBehaviour
{
	abstract public void Enter (T owner);
	abstract public void Execute();
	abstract public void Exit();
}
