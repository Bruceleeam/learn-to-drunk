using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<Cocktail> _cocktails = new List<Cocktail>();

    // Start is called before the first frame update
    void Start()
    {
        Init();
        Debug.Log("Base: " + RandomCocktail().Base.GetType().Name);
        Debug.Log("Flavoring: " + RandomCocktail().Flavoring.GetType().Name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Init()
    {
        _cocktails.Add(new Martini());
        _cocktails.Add(new MoscowMule());

        foreach(Cocktail ct in _cocktails)
        {
            ct.Create();
            ct.Create();
        }
    }

    public Cocktail RandomCocktail()
    {
        return _cocktails[Random.Range(0, _cocktails.Count)];
    }
}
