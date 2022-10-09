using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // BL
    List<Cocktail> _cocktails = new List<Cocktail>();
    Cocktail _cocktail;

    // UI
    public Image _baseIngredient;
    public Image _flavoringIngredient;
    public List<Sprite> _baseIngredients;
    public List<Sprite> _flavoringIngredients;

    // Start is called before the first frame update
    void Start()
    {
        Init();
        _cocktail = RandomCocktail();
        Debug.Log("Cocktail:" + _cocktail.GetType().Name);
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

    public void SwitchBase()
    {
        _baseIngredient.GetComponent<Image>().sprite = _baseIngredients[Random.Range(0, _baseIngredients.Count)];
    }

    public void SwitchFlavoring()
    {
        _flavoringIngredient.GetComponent<Image>().sprite = _flavoringIngredients[Random.Range(0, _flavoringIngredients.Count)];
    }
}
