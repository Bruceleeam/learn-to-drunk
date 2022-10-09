using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flavoring
{
    public abstract class FlavoringIngredient
    {
        public string Name { get; set; }
        public abstract FlavoringIngredient Add();
       
    }
}