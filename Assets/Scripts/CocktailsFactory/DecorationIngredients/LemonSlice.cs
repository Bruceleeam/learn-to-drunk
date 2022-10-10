using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Decoration
{
    public class LemonSlice : DecorationIngredient
    {
        public override DecorationIngredient Add()
        {
            return this;
        }
    }
}
