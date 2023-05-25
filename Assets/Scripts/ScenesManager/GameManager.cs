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
    public Image _barman;
    public static bool _feedback = false;
    public static bool  _cardUnlocking= false;
    public static bool _update = false;
    public GameObject _cardPanel;
    public Text _cardTitle;
    public Text _cardDescription;

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
        Init();

    }

    // Use this for initialization
    void Start()
    {
        
    }

    public void Init()
    {
        foreach (Cocktail ck in Resources.LoadAll("Cocktail", typeof(Cocktail)))
            _cocktails.Add(ck);

        _user_cocktail = new Cocktail();

        FSM.Initialize(this, new IntroState());
    }

    // Update is called once per frame
    void Update()
    {
        FSM.Update();

        if (_feedback)
        {
            _feedback = false;
            string feedbackMessage = "";
            //switch (this.CurrentState())
            //{
            //    case Type.GetType("RightState"):
            //        feedbackMessage = "Risposta Esatta!";
            //        break;
            //    case Type.GetType("WrongState"):
            //        feedbackMessage = "Risposta Errata! Riprova.";
            //        break;
            //    default:
            //        break;
            //}

            if (CurrentState() == Type.GetType("RightAnswerState"))
            {
                feedbackMessage = "Risposta esatta!";
            }

            if (CurrentState() == Type.GetType("WrongAnswerState"))
            {
                feedbackMessage = "Risposta errata! Riprova.";
            }

            if (CurrentState() == Type.GetType("EndState"))
            {
                feedbackMessage = "Partita terminata.";
            }

            StartCoroutine(Feedback(feedbackMessage, null));
        }

        if (_cardUnlocking)
        {
            _cardUnlocking = false;
            UnlockCard();
        }
    }

    public void ChangeState(FSMState<GameManager> state)
    {
        FSM.ChangeState(state);                     
    }

    public Type CurrentState()
    {
        return FSM.CurrentState().GetType();
    }

    public IEnumerator Feedback(string feedback, string barman)
    {
        _task.text = feedback;
        yield return new WaitForSeconds(3);
        _update = true;
    }

    public IEnumerator Feedback(string message)
    {
        yield return null;
    }

    public void Confirm()
    {
        confirm = true;
    }

    public void UnlockCard()
    {
        _cardPanel.SetActive(true);
        _cardTitle.text = _cocktail.name;
        _cardDescription.text = _cocktail._desc;
    }

    public void UpdateState()
    {
        _update = true;
    }

}