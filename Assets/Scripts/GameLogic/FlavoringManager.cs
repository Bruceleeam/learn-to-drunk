using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlavoringManager : MonoBehaviour
{
    List<Flavoring> _flavorings;
    int index;
    GameManager _gameManager;

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

        _flavorings = new List<Flavoring>();
        index = 0;

        foreach (Flavoring fl in Resources.LoadAll("Flavoring", typeof(Flavoring)))
            _flavorings.Add(fl);

        GetComponent<Button>().onClick.AddListener(SpriteSwitching);
    }

    void SpriteSwitching()
    {

        _ = index + 1 == _flavorings.Count ? index = 0 : index++;

        GetComponent<Image>().sprite = _flavorings[index]._image;

        _gameManager._user_cocktail._flavoring = _flavorings[index];

    }

}
