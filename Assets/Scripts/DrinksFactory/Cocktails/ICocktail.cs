using System.Collections;
using System.Collections.Generic;
using Base;
using Flavoring;
using UnityEngine;

public interface ICocktail
{
    IBaseIngredient AddBase();
    IFlavoringIngredient AddFlavoring();
}
