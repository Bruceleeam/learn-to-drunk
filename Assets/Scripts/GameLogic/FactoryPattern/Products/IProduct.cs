using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DesignPatterns.Factory
{
    // a common interface between products
    public interface IProduct
    {
        // add common properties and methods here
        public string ProductName { get; set; }
        public List<GameObject> Ingredients { get; }

        // customize this for each concrete product
        public void Initialize();

        public bool Validate(List<GameObject> ingredients)
        {
            if (Ingredients.Count == ingredients.Count && Ingredients.All(item => ingredients.Any(otherItem => item.name == otherItem.name)))
                return true;
            else
                return false;
        }
    }
}
