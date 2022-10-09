using System.Collections;
using System.Collections.Generic;
using Base;
using Flavoring;
using UnityEngine;

public abstract class Cocktail
{
    public BaseIngredient Base { get; set; }
    public FlavoringIngredient Flavoring { get; set; }
    public abstract void Create();
    public abstract BaseIngredient AddBase();
    public abstract FlavoringIngredient AddFlavoring();

}
