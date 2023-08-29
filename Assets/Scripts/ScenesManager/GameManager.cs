using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DesignPatterns.Factory;
using UnityEditor.VersionControl;

public class GameManager : MonoBehaviour
{
    // SINGLETON
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private FiniteStateMachine<GameManager> FSM = new FiniteStateMachine<GameManager>();
    public UIManager uim;

    public static List<GameObject> _editorIngredients = new List<GameObject>();
    public static List<GameObject> _userIngredients = new List<GameObject>();
    public Creator _creator;
    public IProduct _cocktail;
    public bool _next = false;

    // OBSERVER & ACTIONS
    public event Action<string> UpdateUI;
    public void OnUpdateUI(string message)
    {
        UpdateUI?.Invoke(message);
    }

    public int Lifes { get; set; }

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

    public void WaitForNext(int sec = 3)
    {
        StartCoroutine(WaitForNextCoroutine(sec));
    }

    IEnumerator WaitForNextCoroutine(int sec)
    {
        yield return new WaitForSeconds(sec);
        _next = true;
    }

    public void UpdateTitle(string message)
    {
        uim.UpdateTitleMessage(message);
    }

    public void UpdateInstruction(string message)
    {
        uim.UpdateInstructionMessage(message);
    }

    public void Confirm()
    {
        _next = true;
    }

    public void SetCocktail()
    {
        _cocktail = _creator.GetComponent<Creator>().GetProduct(StaticGameData._gameData._lastTown);
        _userIngredients.Clear();
    }

    public bool ValidateCocktail()
    {
        return _cocktail.Validate(_userIngredients);
    }

    public bool UpdateLifes(int lifes)
    {
        StaticGameData._gameData._lifes += lifes;
        GetComponent<StorageData>().SaveDataLocally(StaticGameData._gameData);
        uim.UpdateLifes(StaticGameData._gameData._lifes);

        return true;
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

        uim.InitIngredients(_editorIngredients);

    }

    public void ActiveInterceptor()
    {
        uim.ActiveInterceptor();
    }

    public void DeactiveInterceptor()
    {
        uim.DeactiveInterceptor();
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