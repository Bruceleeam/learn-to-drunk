using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    // BL
    List<Cocktail> _cocktails = new List<Cocktail>();
    Cocktail _cocktail;

    // UI IN INSPECTOR
    public Text _task;
    public Image _baseIngredient;
    public Image _flavoringIngredient;
    public Image _dyeIngredient;
    public Image _decorationIngredient;
    public List<Sprite> _baseIngredients;
    public List<Sprite> _flavoringIngredients;

    // Start is called before the first frame update
    void Start()
    {
        Init();
        _cocktail = RandomCocktail();
        _task.text = "Prepara un " + _cocktail;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Init()
    {
        _cocktails.Add(new Martini());
        _cocktails.Add(new MoscowMule());

        foreach (Cocktail ct in _cocktails)
        {
            ct.Create();
            ct.Create();
        }
    }

    public Cocktail RandomCocktail()
    {
        return _cocktails[Random.Range(0, _cocktails.Count)];
    }

    public void CheckComposition()
    {
        if (_baseIngredient.GetComponent<Image>().sprite.name.Equals(_cocktail.Base.GetType().Name.ToLower())
            &&
            _flavoringIngredient.GetComponent<Image>().sprite.name.Equals(_cocktail.Flavoring.GetType().Name.ToLower()))
            Debug.Log("OK");
        else
            Debug.Log("ERROR");
    }

    public void SwitchSprite(string ingredientType)
    {
        Sprite current = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;

        switch (ingredientType)
        {
            case "BASE":
                current = Randomize(_baseIngredients, current);
                break;
            case "FLAVORING":
                current = Randomize(_flavoringIngredients, current);
                break;
            default:
                break;
        }

        EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite = current;
    }

    public Sprite Randomize(List<Sprite> ingredientList, Sprite current)
    {
        
        Sprite temp;

        do
        {
            temp = ingredientList[Random.Range(0, ingredientList.Count)];
        }
        while (current.name.Equals(temp.name));

        return temp;
    }

}
