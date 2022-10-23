using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private FiniteStateMachine<GameManager> FSM = new FiniteStateMachine<GameManager>();

    // Use this for initialization
    void Start()
    {

    }

    public void Init()
    {
        //  Initialize FSM to its first logic state
        FSM.Initialize(this, new IntroState());
    }

    // Update is called once per frame
    void Update()
    {
        FSM.Update();
    }

    public void ChangeState(FSMState<GameManager> state)
    {
        FSM.ChangeState(state);                     // Change the state of FSM that passes from a state to next	
    }

}