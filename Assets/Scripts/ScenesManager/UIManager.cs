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
    public Text _textDialog;
    public Text _textTitle;
    public GameObject _panelCard;
    public Text _textCardTitle;
    public Text _textCardDescription;
    public GameObject _panelInterceptor;
    public List<GameObject> _lifes;
    public List<GameObject> _ingPlaceholders;
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
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _ = GameManager._userIngredients.Count > 0 && gm.CurrentState() == typeof(PlayState)?
            _confirm.GetComponent<Button>().interactable = true :
            _confirm.GetComponent<Button>().interactable = false;
    }

    public void UpdateTitleMessage(string message)
    {
        _textTitle.text = message;
    }

    public void UpdateInstructionMessage(string message)
    {
        _textDialog.text = message;
    }

    public void ActiveInterceptor()
    {
        _panelInterceptor.SetActive(true);
    }

    public void DeactiveInterceptor()
    {
        _panelInterceptor.SetActive(false);
    }

    public void ShowCard(string title, string description)
    {
        _panelCard.SetActive(true);
        _textCardTitle.text = title;
        _textCardDescription.text = description;
    }

    public bool InitIngredients(List<GameObject> ingredients)
    {
        int index = 0;

        foreach (GameObject placeholder in _ingPlaceholders)
        {
            if (index == ingredients.Count) return true;

            GameObject ingredient = ingredients[index++];
            ingredient.transform.position = placeholder.transform.position;
            ingredient.transform.SetParent(placeholder.transform.parent);
            Destroy(placeholder.gameObject);
        }

        return true;
    }

    public void UpdateLifes (int lifes)
    {

        for (int i = _lifes.Count(); i > lifes; i--)
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
}