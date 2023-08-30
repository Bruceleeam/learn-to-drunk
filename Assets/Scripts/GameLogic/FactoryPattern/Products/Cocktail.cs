using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DesignPatterns.Factory
{
    public class Cocktail : MonoBehaviour, IProduct
    {
        [SerializeField] public string _name;
        [SerializeField] public List<GameObject> _ingredients;

        public string Name { get => _name; set => _name = value; }
        public List<GameObject> Ingredients { get => _ingredients; }

        public void Initialize()
        {
            
        }

        public bool Validate(List<GameObject> ingredients)
        {
            if (Ingredients.Count == ingredients.Count && Ingredients.All(item => ingredients.Any(otherItem => item.name == otherItem.name)))
                return true;
            else
                return false;
        }
    }
}
