using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Factory
{
    public class MoscowMuleFactory : Factory
    {
        // used to create a Prefab
        [SerializeField] private MoscowMule moscowMulePrefab;

        public override IProduct GetBase(Vector3 position)
        {
            // create a Prefab instance and get the product component
            GameObject instanceBase = Instantiate(moscowMulePrefab.gameObject, position, Quaternion.identity);
            MoscowMule moscowMule = instanceBase.GetComponent<MoscowMule>();

            // each product contains its own logic
            moscowMule.Initialize();

            return moscowMule;
        }
    }
}
