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
        PlayerPrefs.DeleteKey("LastTown");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NewGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ClearCard()
    {
        _cocktailCardTitle.text = "";
        _cocktailCardDesc.text = "";
    }
}
