using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject _cardButtonsContent;
    public GameObject _cocktailCardBtn;
    public GameObject _cocktailCard;
    public Text _cocktailCardTitle;
    public Text _cocktailCardDesc;
    //public List<Cocktail> _cocktails = new List<Cocktail>();

    // Start is called before the first frame update
    void Start()
    {
        //foreach (Cocktail ck in Resources.LoadAll("Cocktail", typeof(Cocktail)))
        //    _cocktails.Add(ck);

        //foreach (Cocktail ck in _cocktails)
        //{
        //    if (PlayerPrefs.HasKey(ck.name))
        //    {
        //        GameObject temp = Instantiate(_cocktailCardBtn);
        //        temp.GetComponent<CocktailCardBtn>()._cocktailRef = ck;
        //        temp.name = ck.name;
        //        temp.transform.parent = _cardButtonsContent.transform;
        //        temp.transform.GetChild(0).GetComponent<Image>().sprite = ck.image;
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NewGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //public void SetCard(Cocktail _cocktail)
    //{
    //    _cocktailCard.SetActive(true);
    //    _cocktailCardTitle.text = _cocktail._title;
    //    _cocktailCardDesc.text = _cocktail._desc;
    //}

    public void ClearCard()
    {
        _cocktailCardTitle.text = "";
        _cocktailCardDesc.text = "";
    }
}
