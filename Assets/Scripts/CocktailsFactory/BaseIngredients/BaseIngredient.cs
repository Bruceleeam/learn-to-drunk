using System.Collections;
using System.Collections.Generic;
using Base;
using UnityEngine;

public abstract class BaseIngredient
{
    public string Name { get; set; }
    public abstract BaseIngredient Add();
}
