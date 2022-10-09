using System.Collections;
using System.Collections.Generic;
using Base;
using Flavoring;
using UnityEngine;

public class MoscowMule : Cocktail
{
    public override BaseIngredient AddBase()
    {
        return new Vodka();
    }

    public override FlavoringIngredient AddFlavoring()
    {
        return new GingerBeer();
    }

    public override void Create()
    {
        Base = AddBase();
        Flavoring = AddFlavoring();
    }
}
