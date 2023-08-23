using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DesignPatterns.Factory
{
    public class Negroni : MonoBehaviour, IProduct
    {
        [SerializeField] private string productName = "Negroni";
        [SerializeField] public List<GameObject> ingredients;

        public string ProductName { get => productName; set => productName = value ; }
        public List<GameObject> Ingredients { get => ingredients; }

        public void Initialize()
        {
            // any unique logic to this product
            gameObject.name = productName;
        }
    }
}
