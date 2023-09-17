using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public GameObject _buttonCocktailCards;
    public GameObject _cardButtonsContent;
    public GameObject _cocktailCardBtn;
    public GameObject _panelCard;
    public Text _textCardTitle;
    public Text _textCardDescription;
    public GameObject _continue;
    //public List<Cocktail> _cocktails = new List<Cocktail>();

    // Start is called before the first frame update
    void Start()
    {
        if (StaticGameData._gameData.Town != null && StaticGameData._gameData.Lifes > 0)
            _continue.SetActive(true);

        if (StaticGameData._gameData.Unlocked.Count > 0)
        {
            _buttonCocktailCards.SetActive(true);

            foreach (Card unlocked in StaticGameData._gameData.Unlocked)
            {
                GameObject tempCard = Instantiate(_cocktailCardBtn, new Vector3(0, 0, 0), Quaternion.identity);
                tempCard.transform.SetParent(_cardButtonsContent.transform);
                tempCard.transform.localScale = new Vector3(1, 1, 1);
                tempCard.name = unlocked.Name;
                tempCard.transform.GetChild(0).GetComponent<Text>().text = unlocked.Name;
            }
        }            
    }

    // Update is called once per frame
    void Update()
    {
        var lastClick = EventSystem.current.currentSelectedGameObject ?? null;

        if (lastClick && lastClick.tag.Equals("CardButton"))
            ActivePanelCard(lastClick);

    }

    public void NewGame()
    {
        StaticGameData._gameData = new GameData(3, null, null, StaticGameData._gameData.Unlocked);
        SceneManager.LoadScene("Map");
    }

    public void Continue()
    {
        SceneManager.LoadScene("Map");
    }

    public void ClearCard()
    {
        _textCardTitle.text = "";
        _textCardDescription.text = "";
    }

    public void ActivePanelCard(GameObject card)
    {
        _panelCard.SetActive(true);
        Card temp = StaticGameData._gameData.Unlocked.Find(x => x.Name == card.name);
        _textCardTitle.text = temp.Name;
        _textCardDescription.text    = temp.Description;
    }
}
