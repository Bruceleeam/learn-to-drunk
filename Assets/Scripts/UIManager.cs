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

    public GameManager gm;
    public GameObject _ingredientUI;
    public IProduct _cocktail;
    public GameObject _content;
    public Text _message;
    public Image _barman;
    public Sprite _barmanWelcomer;
    public Sprite _barmanMixing;
    public Sprite _barmanHappy;
    public Sprite _barmanSad;    

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

        RegisterSubject();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // OBSERVER
    public bool RegisterSubject()
    {
        gm.InitSVChoices += OnInitSVChoices;
        gm.PrintMessage += OnPrintMessage;
        gm.SwitchBarman += OnSwitchBarman;
        gm.RightAnswer += OnRightAnswer;
        gm.WrongAnswer += OnWrongAnswer;
        return true;
    }

    private void OnPrintMessage()
    {
        _message.text = GameManager.stateMessage;
    }

    private void OnInitSVChoices()
    {
        foreach (GameObject ing in gm._cocktail.Ingredients)
        {
            GameObject temp = Instantiate(_ingredientUI);
            temp.tag = ing.tag;
            temp.transform.GetChild(0).GetComponent<Text>().text = ing.tag;
            temp.transform.parent = _content.transform;
        }
    }

    private void OnRightAnswer()
    {
        OnPrintMessage();
    }

    private void OnWrongAnswer()
    {
        OnPrintMessage();
    }

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

}