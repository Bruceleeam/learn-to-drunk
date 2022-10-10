using System.Collections;
using System.Collections.Generic;
using Base;
using UnityEngine;

namespace Dye
{
    public abstract class DyeIngredient
    {
        public string Name { get; set; }
        public abstract DyeIngredient Add();
    }
}
