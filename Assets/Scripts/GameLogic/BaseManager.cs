using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseManager : MonoBehaviour
{
    List<Base> _bases;
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
        _bases = new List<Base>();
        index = 0;

        foreach (Base bs in Resources.LoadAll("Base", typeof(Base)))
            _bases.Add(bs);

        GetComponent<Button>().onClick.AddListener(SpriteSwitching);
    }

    void SpriteSwitching()
    {

        _ = index + 1 == _bases.Count ? index = 0 : index++;

        GetComponent<Image>().sprite = _bases[index]._image;
        transform.GetChild(0).GetComponent<Text>().text = _bases[index].name;

        _gameManager._user_cocktail._base = _bases[index];
        
    }

}
