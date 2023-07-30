using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DesignPatterns.Factory;
using static Unity.VisualScripting.Metadata;
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
    public List<GameObject> _ingredients;
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
        UpdateLifes();
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        bool allHooked = _userIngredients.All(obj => obj.GetComponent<DropItem>()._lockedGO != null) && gm.CurrentState() == Type.GetType("PlayState") ? _confirm.GetComponent<Button>().interactable = true : _confirm.GetComponent<Button>().interactable = false;
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
        foreach (GameObject ing in _ingredients)
        {
            ing.GetComponent<DragItem>().enabled = true;
            ing.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }

        _confirm.SetActive(true);

    }

    private void OnDeactiveDrag()
    {
        foreach (GameObject ing in _ingredients)
        {
            ing.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            ing.GetComponent<DragItem>().enabled = false;
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
        if (_lifes.Count > gm.Lifes)
        {
            for(int i = _lifes.Count(); i > gm.Lifes; i--)
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