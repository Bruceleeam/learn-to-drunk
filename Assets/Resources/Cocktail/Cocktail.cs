using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Cocktail", menuName = "Cocktail", order = 1)]
public class Cocktail : ScriptableObject
{
    public Sprite image;
    public Base _base;
    public Flavoring _flavoring;
    public Dye _dye;
    public Decoration _decoration;
    public string _desc;
    private bool _cardUnlocked;

    public Cocktail()
    {
        _base = null;
        _flavoring = null;
        _dye = null;
        _decoration = null;
    }

    public void SetCardUnlocked( bool val)
    {
        _cardUnlocked = val;

    }
}
