using System.Collections;
using System.Collections.Generic;
using Base;
using Flavoring;
using UnityEngine;

public class Martini : Cocktail
{
    public override BaseIngredient AddBase()
    {
        return new Gin();
    }

    public override FlavoringIngredient AddFlavoring()
    {
        return new Vermouth();
    }

    public override void Create()
    {
        Base = AddBase();
        Flavoring = AddFlavoring();
    }
}
