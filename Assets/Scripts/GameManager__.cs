//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class GameManager : MonoBehaviour
//{
//    public List<Cocktail> cocktails;
//    public GameObject _ingredients;
//    public List<Base> bases;
//    public List<Flavoring> flavorings;
//    Cocktail cocktail;
//    public GameObject _ingredient;

//    // Start is called before the first frame update
//    void Start()
//    {
//        int index = Random.Range(0, cocktails.Count);
//        cocktail = cocktails[index];
//        if (cocktail._base)
//            InitIngredient();
//        if (cocktail._flavoring)
//            InitIngredient();
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }

//    public void InitIngredient()
//    {
//        GameObject ing = Instantiate(_ingredient);
//        List<Base>.Enumerator en = bases.GetEnumerator();

//        ing.transform.GetChild(0).GetComponent<Image>().sprite = en.Current._image;
//        en.MoveNext();
//        ing.transform.parent = _ingredients.transform;
//    }

//}
