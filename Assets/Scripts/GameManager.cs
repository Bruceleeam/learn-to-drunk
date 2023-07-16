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

    // OBSERVER

    public static string stateMessage;
    public static int spriteCode;

    public event Action Completed;
    protected void OnCompleted()
    {
        Completed?.Invoke();
    }

    public event Action PrintMessage;
    protected void OnPrintMessage()
    {
        PrintMessage?.Invoke();
    }

    public event Action SwitchBarman;
    protected void OnSwitchBarman()
    {
        SwitchBarman?.Invoke();
    }

    public event Action InitSVChoices;
    protected void OnInitSVChoices()
    {
        InitSVChoices?.Invoke();
    }

    public event Action RightAnswer;
    protected void OnRightAnswer()
    {
        RightAnswer?.Invoke();
    }

    public event Action WrongAnswer;
    protected void OnWrongAnswer()
    {
        WrongAnswer?.Invoke();
    }

    int _life;
    public List<Button> _lifeIcons;
    int _maxLife = 3;

    private FiniteStateMachine<GameManager> FSM = new FiniteStateMachine<GameManager>();
    public GameObject _ingredientUI;
    public IProduct _cocktail;
    public GameObject _content;
    public List<String> _userIngredients;
    public List<Image> _ingredients;
    public List<Image> _placeholders;
    public Creator _creator;
    //public Cocktail _user_cocktail;
    public Button _confirm;
    public static bool confirm = false;
    public Text _task;
    public Image _barman;

    public static bool _feedback = false;
    public static bool _cardUnlocking = false;
    public static bool _update = false;
    public GameObject _cardPanel;
    public Text _cardTitle;
    public Text _cardDescription;
    public Text _timer;
    public float _sec;
    string boardMessage = "";

    public bool registerSubject(BaseState fsmState)
    {
        fsmState.Entering += OnEntering;
        return true;
    }

    private void OnEntering()
    {
        StartCoroutine(ThrowEvents());
    }

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

    public IEnumerator ThrowEvents()
    {
        OnPrintMessage();
        OnSwitchBarman();
        OnInitSVChoices();
        yield return new WaitForSeconds(3);
        OnCompleted();
    }

    public void Confirm()
    {
        foreach (Transform ing in _content.GetComponentsInChildren<Transform>())
            _userIngredients.Add(ing.name);

        confirm = true;
    }

    public void UpdateState()
    {
        _update = true;
    }

}