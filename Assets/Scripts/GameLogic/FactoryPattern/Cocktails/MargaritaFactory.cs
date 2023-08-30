using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Factory
{
    public class MargaritaFactory : Factory
    {
        // used to create a Prefab
        [SerializeField] private Margarita productPrefab;

        public override IProduct GetBase(Vector3 position)
        {
            // create a Prefab instance and get the product component
            GameObject instanceBase = Instantiate(productPrefab.gameObject, position, Quaternion.identity);
            Margarita product = instanceBase.GetComponent<Margarita>();

            // each product contains its own logic
            product.Initialize();

            return product;
        }
    }
}
