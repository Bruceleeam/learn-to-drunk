using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocktailCardBtn : MonoBehaviour
{
    public Cocktail _cocktailRef;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCardCocktail()
    {
        GameObject.Find("MenuManager").GetComponent<MenuManager>().SetCard(_cocktailRef);
    }
}
