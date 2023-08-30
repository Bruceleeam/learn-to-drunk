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
        public string Name { get; set; }
        public List<GameObject> Ingredients { get; }

        // customize this for each concrete product
        public void Initialize();

        public bool Validate(List<GameObject> ingredients);
    }
}
