using System.Collections;
using System.Collections.Generic;
using Base;
using Decoration;
using Dye;
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

    public override DyeIngredient AddDye()
    {
        return null;
    }

    public override DecorationIngredient AddDecoration()
    {
        return new LemonSlice();
    }

    public override void Create()
    {
        Base = AddBase();
        Flavoring = AddFlavoring();
        Dye = AddDye();
        Decoration = AddDecoration();
    }
}
