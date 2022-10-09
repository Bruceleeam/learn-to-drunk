using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flavoring
{
    public class Vermouth: FlavoringIngredient
    {
        public override FlavoringIngredient Add()
        {
            return this;
        }
    }
}