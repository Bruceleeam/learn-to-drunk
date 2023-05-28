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
    public Button _confirm;
    public static bool confirm = false;
    public Text _task;
    public Image _barman;
    public Sprite _barmanWelcomer;
    public Sprite _barmanMixing;
    public Sprite _barmanHappy;
    public Sprite _barmanSad;
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
        _barman.sprite = _barmanWelcomer;

        FSM.Initialize(this, new IntroState());
    }

    // Update is called once per frame
    void Update()
    {
        FSM.Update();

        if (CurrentState() == Type.GetType("PlayState"))
            _barman.sprite = _barmanMixing;

        if (_feedback)
        {
            _feedback = false;
            string feedbackMessage = "";
            
            if (CurrentState() == Type.GetType("RightAnswerState"))
            {
                _barman.sprite = _barmanHappy;
                feedbackMessage = "Risposta esatta!";
            }

            if (CurrentState() == Type.GetType("WrongAnswerState"))
            {
                _barman.sprite = _barmanSad;
                feedbackMessage = "Risposta errata! Riprova.";
            }

            if (CurrentState() == Type.GetType("EndState"))
            {
                _barman.sprite = _barmanWelcomer;
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
        _confirm.interactable = false;
        yield return new WaitForSeconds(3);
        _barman.sprite = _barmanWelcomer;
        _confirm.interactable = true;
        _update = true;
    }

    public void Confirm()
    {
        confirm = true;
    }

    public void UnlockCard()
    {
        _confirm.interactable = false;
        _cardPanel.SetActive(true);
        _cardTitle.text = _cocktail.name;
        _cardDescription.text = _cocktail._desc;
    }

    public void UpdateState()
    {
        _update = true;
    }

}