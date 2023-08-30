using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DesignPatterns.Factory
{
    public class CocktailFactory : Factory
    {
        // used to create a Prefab
        [SerializeField] private Cocktail cocktailPrefab;

        public override IProduct GetProduct(Vector3 position)
        {
            // create a Prefab instance and get the product component
            GameObject instanceBase = Instantiate(cocktailPrefab.gameObject, position, Quaternion.identity);
            Cocktail product = instanceBase.GetComponent<Cocktail>();

            // each product contains its own logic
            product.Initialize();

            return product;
        }
    }
}
