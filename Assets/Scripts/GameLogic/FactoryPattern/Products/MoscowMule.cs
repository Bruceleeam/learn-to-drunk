using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Factory
{
    public class MoscowMule : MonoBehaviour, IProduct
    {
        [SerializeField] private string productName = "Moscow Mule";
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
