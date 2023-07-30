using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DesignPatterns.Factory;
using static Unity.VisualScripting.Metadata;

public class GameManager : MonoBehaviour
{
    // SINGLETON
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    public bool _next = false;

    // OBSERVER & ACTIONS
    public event Action<string> UpdateUI;
    public void OnUpdateUI(string message)
    {
        UpdateUI?.Invoke(message);
    }

    public event Action InitSVChoices;
    public void OnInitSVChoices()
    {
        InitSVChoices?.Invoke();
    }

    public event Action DecreaseLife;
    public void OnDecreaseLife()
    {
        DecreaseLife?.Invoke();
    }

    public event Action CheckLife;
    public void OnCheckLife()
    {
        CheckLife?.Invoke();
    }

    public event Action ActiveDrag;
    public void OnActiveDrag()
    {
        ActiveDrag?.Invoke();
    }

    public event Action DeactiveDrag;
    public void OnDeactiveDrag()
    {
        DeactiveDrag?.Invoke();
    }

    private FiniteStateMachine<GameManager> FSM = new FiniteStateMachine<GameManager>();
    
    public static List<GameObject> _userIngredients = new List<GameObject>();
    public Creator _creator;
    public IProduct _cocktail;

    private static int _lifes = 3;
    public int Lifes
    {
        get => _lifes;
        set => _lifes = value;
    }

    public static bool _cardUnlocking = false;
    public GameObject _cardPanel;
    public Text _cardTitle;
    public Text _cardDescription;
    public Text _timer;
    public float _sec;
    string boardMessage = "";

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
        Init();
    }

    public void Init()
    {
        FSM.Initialize(this, new IntroState());
    }

    // Update is called once per frame
    void Update()
    {
        if(_next)
            FSM.Update();
    }

    public void ChangeState(FSMState<GameManager> state)
    {
        FSM.ChangeState(state);
    }

    public Type CurrentState()
    {
        return FSM.CurrentState().GetType();
    }

    public void Confirm()
    {
        Debug.Log("A");

        _next = true;
    }

}