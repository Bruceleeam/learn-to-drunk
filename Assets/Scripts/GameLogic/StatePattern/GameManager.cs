using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private FiniteStateMachine<GameManager> FSM = new FiniteStateMachine<GameManager>();
    public List<Cocktail> _cocktails = new List<Cocktail>();
    public Cocktail _cocktail;
    public Cocktail _user_cocktail;
    public static bool confirm = false;
    public Text _task;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Use this for initialization
    void Start()
    {
        foreach (Cocktail ck in Resources.LoadAll("Cocktail", typeof(Cocktail)))
            _cocktails.Add(ck);

        _cocktail = _cocktails[new System.Random().Next(0, _cocktails.Count)];

        _user_cocktail = new Cocktail();

        Init();

    }

    public void Init()
    {
        FSM.Initialize(this, new IntroState());
    }

    // Update is called once per frame
    void Update()
    {
        FSM.Update();
    }

    public void ChangeState(FSMState<GameManager> state)
    {
        FSM.ChangeState(state);                     
    }

}