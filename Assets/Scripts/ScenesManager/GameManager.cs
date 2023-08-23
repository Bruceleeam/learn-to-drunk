using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DesignPatterns.Factory;

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

    public static List<GameObject> _editorIngredients = new List<GameObject>();
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
        Lifes = StaticGameData._gameData._lifes;
        FSM.Initialize(this, new IntroState());
        LoadRandomObjectsFromResources();
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
        _next = true;
    }

    public void LoadRandomObjectsFromResources()
    {
        _editorIngredients.Clear();

        // Ottieni tutti gli oggetti nella cartella Resources
        GameObject[] allObjects = Resources.LoadAll<GameObject>("Ingredients");

        // Controllo per assicurarti di non superare il limite
        int numberOfObjectsLoaded = 0;

        // Generatore casuale
        System.Random random = new System.Random();

        // Lista per tenere traccia degli indici degli oggetti caricati
        List<int> loadedObjectIndices = new List<int>();
        int randomIndex = -1;

        while (numberOfObjectsLoaded < _cocktail.Ingredients.Count && loadedObjectIndices.Count < allObjects.Length)
        {
            // Genera un indice casuale

            do
            {
                randomIndex = random.Next(0, allObjects.Length);
            } while (!_cocktail.Ingredients.Contains(allObjects[randomIndex]));


            // Assicurati che l'indice non sia stato già caricato
            if (!loadedObjectIndices.Contains(randomIndex))
            {
                // Carica e istanzia l'oggetto
                GameObject gameObject = Instantiate(allObjects[randomIndex] as GameObject);
                gameObject.name = allObjects[randomIndex].name;
                // Fai qualcosa con l'oggetto se necessario
                _editorIngredients.Add(gameObject);

                // Aggiungi l'indice all'elenco degli indici caricati
                loadedObjectIndices.Add(randomIndex);
                numberOfObjectsLoaded++;
            }
        }

        while (numberOfObjectsLoaded < 20 && loadedObjectIndices.Count < allObjects.Length)
        {
            // Genera un indice casuale
            randomIndex = random.Next(0, allObjects.Length);

            // Assicurati che l'indice non sia stato già caricato
            if (!loadedObjectIndices.Contains(randomIndex))
            {
                // Carica e istanzia l'oggetto
                GameObject gameObject = Instantiate(allObjects[randomIndex] as GameObject);
                gameObject.name = allObjects[randomIndex].name;
                // Fai qualcosa con l'oggetto se necessario
                _editorIngredients.Add(gameObject);

                // Aggiungi l'indice all'elenco degli indici caricati
                loadedObjectIndices.Add(randomIndex);
                numberOfObjectsLoaded++;
            }
        }

        Shuffle(_editorIngredients);
    }

    public static void Shuffle<T>(List<T> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;

        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);

            // Scambia list[n] con list[k]
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}