using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class IngredientManager : MonoBehaviour
{
    GameManager _gameManager;
    int _index;
    List<ScriptableObject> _ingredients;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Init()
    {
        _gameManager = GameManager.Instance;
        _index = 0;
        _ingredients = new List<ScriptableObject>();
        Type type = Type.GetType(tag);

        foreach (ScriptableObject obj in Resources.LoadAll(tag, type))
            _ingredients.Add(obj);

        GetComponent<Button>().onClick.AddListener(SpriteSwitching);
        GetComponent<Button>().onClick.Invoke();
        SetCocktail();
    }

    void SpriteSwitching()
    {
        Debug.Log("state:" + _gameManager.CurrentState());
        if (_gameManager.CurrentState() != Type.GetType("IntroState") && _gameManager.CurrentState() != Type.GetType("PlayState"))
            return;
        if (_gameManager.CurrentState() == Type.GetType("IntroState"))
        {
            _index = new System.Random().Next(0,_ingredients.Count);
            GetComponent<Image>().sprite = ((Ingredient)_ingredients[_index])._image;
            transform.GetChild(0).GetComponent<Text>().text = _ingredients[_index].name;
        }
        else
        {
            int temp;

            do
            {
                temp = new System.Random().Next(0, _ingredients.Count);
            } while (temp == _index);

            _index = temp;

            GetComponent<Image>().sprite = ((Ingredient)_ingredients[_index])._image;
            transform.GetChild(0).GetComponent<Text>().text = _ingredients[_index].name;

        }
        

        SetCocktail();
    }

    void SetCocktail()
    {
        switch (tag)
        {
            case "Base":
                _gameManager._user_cocktail._base = _ingredients[_index] as Base;
                break;
            case "Flavoring":
                _gameManager._user_cocktail._flavoring = _ingredients[_index] as Flavoring;
                break;
            case "Dye":
                _gameManager._user_cocktail._dye = _ingredients[_index] as Dye;
                break;
            case "Decoration":
                _gameManager._user_cocktail._decoration = _ingredients[_index] as Decoration;
                break;
            default:
                break;
        }
    }
}