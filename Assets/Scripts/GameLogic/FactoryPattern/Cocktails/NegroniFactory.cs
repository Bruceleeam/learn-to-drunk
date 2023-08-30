using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DesignPatterns.Factory
{
    public class NegroniFactory : Factory
    {
        // used to create a Prefab
        [SerializeField] private Negroni productPrefab;

        public override IProduct GetBase(Vector3 position)
        {
            // create a Prefab instance and get the product component
            GameObject instanceBase = Instantiate(productPrefab.gameObject, position, Quaternion.identity);
            Negroni product = instanceBase.GetComponent<Negroni>();

            // each product contains its own logic
            product.Initialize();

            return product;
        }
    }
}
