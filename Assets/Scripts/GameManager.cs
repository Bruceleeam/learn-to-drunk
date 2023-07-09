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
    // Action Feedback
    //public event Action PrintFeedback;
    //protected void OnFeedback()
    //{
    //    PrintFeedback?.Invoke();
    //}

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
    public static bool  _cardUnlocking= false;
    public static bool _update = false;
    public GameObject _cardPanel;
    public Text _cardTitle;
    public Text _cardDescription;
    public Text _timer;
    public float _sec;
    string boardMessage = "";

    public bool registerSubject(ConcreteState fsmState)
    {
        fsmState.Entering += OnEntering;
        return true;
    }

    private void OnEntering()
    {
        StartCoroutine(Feedback());
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
        //foreach (Cocktail ck in Resources.LoadAll("Cocktail/" + PlayerPrefs.GetString("LastTown"), typeof(Cocktail)))
        //    _cocktails.Add(ck);

        //_user_cocktail = new Cocktail();
        //_barman.sprite = _barmanWelcomer;

        //InitLife();
        

        FSM.Initialize(this, new IntroState());
    }

    // Update is called once per frame
    void Update()
    {
        FSM.Update();

//        if (CurrentState() == Type.GetType("IntroState"))
//        {
////            _barman.sprite = _barmanWelcomer;
//            boardMessage = "Preparati per il prossimo Cocktail!";
            
//        }

        //if (CurrentState() == Type.GetType("PlayState"))
        //{
        //    //_barman.sprite = _barmanMixing;
        //    boardMessage = _cocktail.ProductName;
        //}

        //if (_feedback)
        //{
        //    _feedback = false;
            
        //    if (CurrentState() == Type.GetType("RightAnswerState"))
        //    {
        //        //_barman.sprite = _barmanHappy;
        //        boardMessage = "Risposta esatta!";
        //    }

        //    if (CurrentState() == Type.GetType("WrongAnswerState"))
        //    {
        //        //_barman.sprite = _barmanSad;
        //        boardMessage = "Risposta errata! Riprova.";
        //    }

        //    if (CurrentState() == Type.GetType("EndState"))
        //    {
        //        //_barman.sprite = _barmanWelcomer;
        //        boardMessage = "Riprendi la valigia! Il viaggio continua ...";
        //    }

        //    if (CurrentState() == Type.GetType("GameOverState"))
        //    {
        //        //_barman.sprite = _barmanSad;
        //        boardMessage = "Non sai bere ... si torna a casa!";
        //    }

        //    StartCoroutine(Feedback(boardMessage, null));
        //}

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
            //if (_sec < 0)
            //{
            //    _timer.text = "0";
            //    // GameOver();
            //    FSM.ChangeState(new EndState());
            //}
            //else
            //{
            //    _sec -= Time.deltaTime;
            //    _timer.text = Math.Round(_sec).ToString();
            //}
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

    

    public IEnumerator Feedback()
    {
        OnPrintMessage();
        OnSwitchBarman();
        yield return new WaitForSeconds(3);
        OnCompleted();
        if(CurrentState() == Type.GetType("IntroState"))
        {
            for (int i = 0; i < _cocktail.GetBasesNr(); i++)
            {
                GameObject temp = Instantiate(_ingredientUI);
                temp.tag = "Base";
                temp.transform.GetChild(0).GetComponent<Text>().text = "Base";
                temp.transform.parent = _content.transform;
                
            }
                
            for (int i = 0; i < _cocktail.GetFlavoringsNr(); i++)
            {
                GameObject temp = Instantiate(_ingredientUI);
                temp.tag = "Flavoring";
                temp.transform.GetChild(0).GetComponent<Text>().text = "Flavoring";
                temp.transform.parent = _content.transform;
            }
                
            for(int i = 0; i < _ingredients.Count; i++)
            {
                _placeholders[i].name = _ingredients[i].name;
                _placeholders[i].sprite = _ingredients[i].sprite;
                _placeholders[i].tag = _ingredients[i].tag;
            }
        }
        if (CurrentState() == Type.GetType("EndState"))
            SceneManager.LoadScene("Map");
        if (CurrentState() == Type.GetType("GameOverState"))
            SceneManager.LoadScene("Menu");
    }

    public void Confirm()
    {
        foreach (Transform ing in _content.GetComponentsInChildren<Transform>())
            _userIngredients.Add(ing.name);

        confirm = true;
    }

    public void UnlockCard()
    {
        _confirm.interactable = false;
        _cardPanel.SetActive(true);
        Type tipoClasse = Type.GetType("MoscowMule");
        IProduct temp = (IProduct)Activator.CreateInstance(tipoClasse);
        _cardTitle.text = _cocktail.ProductName;
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