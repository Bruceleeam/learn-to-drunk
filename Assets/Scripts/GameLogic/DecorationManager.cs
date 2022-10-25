using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecorationManager : MonoBehaviour
{
    List<Decoration> _decorations;
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
        _decorations = new List<Decoration>();
        index = 0;

        foreach (Decoration dt in Resources.LoadAll("Decoration", typeof(Decoration)))
            _decorations.Add(dt);

        GetComponent<Button>().onClick.AddListener(SpriteSwitching);
    }

    void SpriteSwitching()
    {

        _ = index + 1 == _decorations.Count ? index = 0 : index++;

        GetComponent<Image>().sprite = _decorations[index]._image;
        transform.GetChild(0).GetComponent<Text>().text = _decorations[index].name;

        _gameManager._user_cocktail._decoration = _decorations[index];
        
    }

}
