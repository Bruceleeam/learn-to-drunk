using System.Collections;
using System.Collections.Generic;
using Base;
using Decoration;
using Dye;
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
   
    public override DyeIngredient AddDye()
    {
        return new LemonJuice();
    }

    public override DecorationIngredient AddDecoration()
    {
        return null;
    }

    public override void Create()
    {
        Base = AddBase();
        Flavoring = AddFlavoring();
        Dye = AddDye();
        Decoration = AddDecoration();
    }
}
