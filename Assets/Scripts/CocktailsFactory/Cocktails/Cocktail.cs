using System.Collections;
using System.Collections.Generic;
using Base;
using Flavoring;
using Dye;
using Decoration;
using UnityEngine;

public abstract class Cocktail
{
    public BaseIngredient Base { get; set; }
    public FlavoringIngredient Flavoring { get; set; }
    public DyeIngredient Dye { get; set; }
    public DecorationIngredient Decoration { get; set; }
    public abstract void Create();
    public abstract BaseIngredient AddBase();
    public abstract FlavoringIngredient AddFlavoring();
    public abstract DyeIngredient AddDye();
    public abstract DecorationIngredient AddDecoration();

}
