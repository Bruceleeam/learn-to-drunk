using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DyeManager : MonoBehaviour
{
    List<Dye> _dies;
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
        _dies = new List<Dye>();
        index = 0;

        foreach (Dye dy in Resources.LoadAll("Dye", typeof(Dye)))
            _dies.Add(dy);

        GetComponent<Button>().onClick.AddListener(SpriteSwitching);
    }

    void SpriteSwitching()
    {

        _ = index + 1 == _dies.Count ? index = 0 : index++;

        GetComponent<Image>().sprite = _dies[index]._image;
        transform.GetChild(0).GetComponent<Text>().text = _dies[index].name;

        _gameManager._user_cocktail._dye = _dies[index];
        
    }

}
