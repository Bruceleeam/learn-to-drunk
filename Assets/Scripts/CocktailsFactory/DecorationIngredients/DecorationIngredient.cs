using System.Collections;
using System.Collections.Generic;
using Base;
using UnityEngine;

namespace Decoration
{
    public abstract class DecorationIngredient
    {
        public string Name { get; set; }
        public abstract DecorationIngredient Add();
    }
}