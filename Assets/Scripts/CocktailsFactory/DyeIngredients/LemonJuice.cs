using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dye
{
    public class LemonJuice : DyeIngredient
    {
        public override DyeIngredient Add()
        {
            return this;
        }
    }
}
