using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DesignPatterns.Factory;
using System.Linq;

public class UIManager : MonoBehaviour
{

    // SINGLETON
    private static UIManager _instance;
    public static UIManager Instance { get { return _instance; } }

    // TO DRAG & DROP BY INSPECTOR
    public GameManager gm;
    public GameObject _ingredientUI;
    public GameObject _content;
    public Text _message;
    public List<GameObject> _lifes;
    public GameObject _bases;
    public GameObject _flavorings;
    public GameObject _decorations;
    public GameObject _dyes;
    List<GameObject> _ingredients = new List<GameObject>();
    public List<GameObject> _userIngredients;
    public GameObject _confirm;

    // FIELDS
    private IProduct _cocktail;

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

        RegisterSubjects();
        UpdateIngredients();
        UpdateLifes();
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _ = GameManager._userIngredients.Count > 0 ? _confirm.GetComponent<Button>().interactable = true : _confirm.GetComponent<Button>().interactable = false;
    }

    // OBSERVER
    public bool RegisterSubjects()
    {
        gm.InitSVChoices += OnInitSVChoices;
        gm.ActiveDrag += OnActiveDrag;
        gm.DeactiveDrag += OnDeactiveDrag;
        gm.UpdateUI += OnUpdateUI;
        return true;
    }

    public bool UpdateIngredients()
    {
        for (int i = 0; i < _bases.transform.childCount; i++)
        {
            _ingredients.Add(_bases.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < _flavorings.transform.childCount; i++)
        {
            _ingredients.Add(_flavorings.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < _decorations.transform.childCount; i++)
        {
            _ingredients.Add(_decorations.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < _dyes.transform.childCount; i++)
        {
            _ingredients.Add(_dyes.transform.GetChild(i).gameObject);
        }

        return true;
    }

    public bool UnregisterSubjects()
    {
        gm.InitSVChoices -= OnInitSVChoices;
        gm.ActiveDrag -= OnActiveDrag;
        gm.DeactiveDrag -= OnDeactiveDrag;
        gm.UpdateUI -= OnUpdateUI;
        return true;
    }

    private void OnInitSVChoices()
    {
        foreach (GameObject ing in gm._cocktail.Ingredients)
        {
            GameObject temp = Instantiate(_ingredientUI);
            temp.tag = ing.tag;
            temp.transform.GetChild(0).GetComponent<Text>().text = ing.tag;
            temp.transform.parent = _content.transform;
            _userIngredients.Add(temp);
        }
    }

    private void OnActiveDrag()
    {
        for (int i = 0; i < _bases.transform.childCount - 1; i++)
        {
            _bases.transform.GetChild(i).GetComponent<Button>().interactable = true;
        }

        for (int i = 0; i < _flavorings.transform.childCount - 1; i++)
        {
            _flavorings.transform.GetChild(i).GetComponent<Button>().interactable = true;
        }

        for (int i = 0; i < _decorations.transform.childCount - 1; i++)
        {
            _decorations.transform.GetChild(i).GetComponent<Button>().interactable = true;
        }

        for (int i = 0; i < _dyes.transform.childCount - 1; i++)
        {
            _dyes.transform.GetChild(i).GetComponent<Button>().interactable = true;
        }

        _confirm.GetComponent<Button>().interactable = true;

    }

    private void OnDeactiveDrag()
    {
        for (int i = 0; i < _bases.transform.childCount - 1; i++)
        {
            _bases.transform.GetChild(i).GetComponent<Button>().interactable = false;
        }

        for (int i = 0; i < _flavorings.transform.childCount - 1; i++)
        {
            _flavorings.transform.GetChild(i).GetComponent<Button>().interactable = false;
        }

        for (int i = 0; i < _decorations.transform.childCount - 1; i++)
        {
            _decorations.transform.GetChild(i).GetComponent<Button>().interactable = false;
        }

        for (int i = 0; i < _dyes.transform.childCount - 1; i++)
        {
            _dyes.transform.GetChild(i).GetComponent<Button>().interactable = false;
        }

        _confirm.GetComponent<Button>().interactable = false;

    }

    private void OnUpdateUI(string message)
    {
        StartCoroutine(Execute(message));
    }

    IEnumerator Execute(string message)
    {
        _message.text = message;
        yield return new WaitForSeconds(3);
        UpdateLifes();
        gm._next = true;
    }

    private void UpdateLifes ()
    {
        if (_lifes.Count > StaticGameData._gameData._lifes)
        {
            for(int i = _lifes.Count(); i > StaticGameData._gameData._lifes; i--)
            {
                if (_lifes[i-1])
                {
                    GameObject toDestroy = _lifes[i-1];
                    _lifes.RemoveAt(i-1);
                    Destroy(toDestroy);
                }                
            }            
        }

        return;
    }

    private void OnDestroy()
    {
        UnregisterSubjects();
    }

}