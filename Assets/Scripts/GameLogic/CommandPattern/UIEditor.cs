using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEditor
{
    private Text _text;
    private GameObject _gameObject;

    public UIEditor()
    {

    }

    public UIEditor(Text text)
    {
        _text = text;
    }

    public UIEditor(GameObject gameObject)
    {
        _gameObject = gameObject;
    }

    public void SetText(string text)
    {
        _text.text = text;
    }

    public string GetText()
    {
        return _text.text;
    }

    public void Active()
    {
        _gameObject.SetActive(true);
    }

    public void Deactive()
    {
        _gameObject.SetActive(false);
    }
}
