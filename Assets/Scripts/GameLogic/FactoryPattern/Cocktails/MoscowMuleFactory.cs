using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DesignPatterns.Factory
{
    public class MoscowMuleFactory : Factory
    {
        // used to create a Prefab
        [SerializeField] private MoscowMule productPrefab;

        public override IProduct GetBase(Vector3 position)
        {
            // create a Prefab instance and get the product component
            GameObject instanceBase = Instantiate(productPrefab.gameObject, position, Quaternion.identity);
            MoscowMule product = instanceBase.GetComponent<MoscowMule>();

            // each product contains its own logic
            product.Initialize();

            return product;
        }
    }
}
