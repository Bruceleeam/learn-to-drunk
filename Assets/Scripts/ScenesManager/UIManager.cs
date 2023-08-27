using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DesignPatterns.Factory;
using System.Linq;
using System.Xml.Linq;
using UnityEditor.Search;

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
    public List<GameObject> _ingPlaceholders;
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
        
    }

    // Use this for initialization
    void Start()
    {
        UpdateIngredients();
        UpdateLifes();
    }

    // Update is called once per frame
    void Update()
    {
        _ = GameManager._userIngredients.Count > 0 && gm.CurrentState() == typeof(PlayState)?
            _confirm.GetComponent<Button>().interactable = true :
            _confirm.GetComponent<Button>().interactable = false;
    }

    // OBSERVER
    public bool RegisterSubjects()
    {
        gm.ActiveDrag += OnActiveDrag;
        gm.DeactiveDrag += OnDeactiveDrag;
        gm.UpdateUI += OnUpdateUI;
        return true;
    }

    public bool UnregisterSubjects()
    {
        gm.ActiveDrag -= OnActiveDrag;
        gm.DeactiveDrag -= OnDeactiveDrag;
        gm.UpdateUI -= OnUpdateUI;
        return true;
    }

    private void OnActiveDrag()
    {
        foreach (GameObject ing in GameManager._editorIngredients)
        {
            ing.GetComponent<Button>().interactable = true;
        }

        _confirm.GetComponent<Button>().interactable = true;
    }

    private void OnDeactiveDrag()
    {
        foreach (GameObject ing in GameManager._editorIngredients)
        {
            ing.GetComponent<Button>().interactable = false;
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

    public bool UpdateIngredients()
    {
        int index = 0;

        foreach (GameObject placeholder in _ingPlaceholders)
        {
            GameObject ingredient = GameManager._editorIngredients[index++];
            ingredient.transform.position = placeholder.transform.position;
            ingredient.transform.SetParent(placeholder.transform.parent);
            Destroy(placeholder.gameObject);
        }

        OnDeactiveDrag();

        return true;
    }

    private void UpdateLifes ()
    {

        for (int i = _lifes.Count(); i > StaticGameData._gameData._lifes; i--)
        {
            if (_lifes[i - 1])
            {
                GameObject toDestroy = _lifes[i - 1];
                _lifes.RemoveAt(i - 1);
                Destroy(toDestroy);
            }
        }

        return;
    }

    private void OnDestroy()
    {
        UnregisterSubjects();
    }

}