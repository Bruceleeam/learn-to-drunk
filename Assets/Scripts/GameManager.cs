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
    public List<Sprite> _dyeIngredients;
    public List<Sprite> _decorationIngredients;

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
        string baseIngredient = _baseIngredient.GetComponent<Image>().sprite.name;
        string flavoringIngredient = _flavoringIngredient.GetComponent<Image>().sprite.name;
        string dyeIngredient = _dyeIngredient.GetComponent<Image>().sprite.name;
        string decoratioIngredient = _decorationIngredient.GetComponent<Image>().sprite.name;

        if ((_cocktail.Base == null || baseIngredient.Equals(_cocktail.Base.GetType().Name.ToLower()))
            &&
            (_cocktail.Flavoring == null || flavoringIngredient.Equals(_cocktail.Flavoring.GetType().Name.ToLower()))
            &&
            (_cocktail.Dye == null || dyeIngredient.Equals(_cocktail.Dye.GetType().Name.ToLower()))
            &&
            (_cocktail.Decoration == null || decoratioIngredient.Equals(_cocktail.Decoration.GetType().Name.ToLower())))
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
            case "DYE":
                current = Randomize(_dyeIngredients, current);
                break;
            case "DECORATION":
                current = Randomize(_decorationIngredients, current);
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
