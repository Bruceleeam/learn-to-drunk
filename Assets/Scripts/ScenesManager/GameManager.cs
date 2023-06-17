﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    int _life;
    public List<Button> _lifeIcons;
    int _maxLife = 3;

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
        Init();

    }

    // Use this for initialization
    void Start()
    {

    }

    public void Init()
    {
        foreach (Cocktail ck in Resources.LoadAll("Cocktail/" + PlayerPrefs.GetString("LastTown"), typeof(Cocktail)))
            _cocktails.Add(ck);

        _user_cocktail = new Cocktail();
        _barman.sprite = _barmanWelcomer;

        InitLife();

        FSM.Initialize(this, new IntroState());
    }

    // Update is called once per frame
    void Update()
    {
        FSM.Update();

        if (CurrentState() == Type.GetType("IntroState"))
        {
            _barman.sprite = _barmanWelcomer;
            boardMessage = "Preparati per il prossimo Cocktail!";
        }

        if (CurrentState() == Type.GetType("PlayState"))
            _barman.sprite = _barmanMixing;

        if (_feedback)
        {
            _feedback = false;
            
            if (CurrentState() == Type.GetType("RightAnswerState"))
            {
                _barman.sprite = _barmanHappy;
                boardMessage = "Risposta esatta!";
            }

            if (CurrentState() == Type.GetType("WrongAnswerState"))
            {
                _barman.sprite = _barmanSad;
                boardMessage = "Risposta errata! Riprova.";
            }

            if (CurrentState() == Type.GetType("EndState"))
            {
                _barman.sprite = _barmanWelcomer;
                boardMessage = "Riprendi la valigia! Il viaggio continua ...";
            }

            if (CurrentState() == Type.GetType("GameOverState"))
            {
                _barman.sprite = _barmanSad;
                boardMessage = "Non sai bere ... si torna a casa!";
            }

            StartCoroutine(Feedback(boardMessage, null));
        }

        if (_cardUnlocking)
        {
            _cardUnlocking = false;
            UnlockCard();
        }

       
        if(CurrentState() != Type.GetType("CardUnlockingState")
            && CurrentState() != Type.GetType("WrongAnswerState")
            && CurrentState() != Type.GetType("RightAnswerState")
            && CurrentState() != Type.GetType("GameOverState")
            && CurrentState() != Type.GetType("IntroState")
            )
        {
            if (_sec < 0)
            {
                _timer.text = "0";
                // GameOver();
                FSM.ChangeState(new EndState());
            }
            else
            {
                _sec -= Time.deltaTime;
                _timer.text = Math.Round(_sec).ToString();
            }
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
        if (CurrentState() == Type.GetType("EndState"))
            SceneManager.LoadScene("Map");
        if (CurrentState() == Type.GetType("GameOverState"))
            SceneManager.LoadScene("Menu");
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

    public void InitLife()
    {
        if (!PlayerPrefs.HasKey("Life"))
            PlayerPrefs.SetInt("Life", _life = _maxLife);

        SetLife(PlayerPrefs.GetInt("Life"));

    }

    public void SetLife(int life)
    {
        PlayerPrefs.SetInt("Life", _life = life);
        SetLifeIcons();
    }

    public int GetLife()
    {
        return _life;
    }

    public void DecreaseLife()
    {
        SetLife(GetLife() - 1);
        SetLifeIcons();
    }

    public void IncreaseLife(int life)
    {
        SetLife(GetLife() == 3 ? GetLife() : (GetLife() + 1));
        SetLifeIcons();
    }

    void SetLifeIcons()
    {
        for (int i = 0; i < GetLife(); i++)
        {
            _lifeIcons[i].interactable = true;
        }

        for (int i = GetLife(); i < _maxLife; i++)
        {
            _lifeIcons[i].interactable = false;
        }
    }
}