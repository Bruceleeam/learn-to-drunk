using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Cocktail", menuName = "Cocktail", order = 1)]
public class Cocktail : ScriptableObject
{
    public Base _base;
    public Flavoring _flavoring;
    public Dye _dye;
    public Decoration _decoration;   
}
