using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DesignPatterns.Factory;
using static Unity.VisualScripting.Metadata;

public class UIManager : MonoBehaviour
{
    // SINGLETON
    private static UIManager _instance;
    public static UIManager Instance { get { return _instance; } }

    // OBSERVER
    public bool registerSubject()
    {
        gm.PrintMessage += OnPrintMessage;
        gm.SwitchBarman += OnSwitchBarman;

        return true;
    }

    private void OnPrintMessage()
    {
        _task.text = GameManager.stateMessage;
    }

    int _life;
    public List<Button> _lifeIcons;
    int _maxLife = 3;

    public GameManager gm;
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

    

    private void OnSwitchBarman()
    {
        switch (GameManager.spriteCode)
        {
            case 0:
                _barman.sprite = _barmanWelcomer;
                break;
            case 1:
                _barman.sprite = _barmanMixing;
                break;
            case 2:
                _barman.sprite = _barmanHappy;
                break;
            case 3:
                _barman.sprite = _barmanSad;
                break;
            default:
                _barman.sprite = _barmanWelcomer;
                break;
        }
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

        Init();
    }

    // Use this for initialization
    void Start()
    {

    }

    public void Init()
    {
        registerSubject();
    }

    // Update is called once per frame
    void Update()
    {

    }
       
}