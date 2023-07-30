using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Factory
{
    public class BrambleFactory
        : Factory
    {
        // used to create a Prefab
        [SerializeField] private Bramble bramblePrefab;

        public override IProduct GetBase(Vector3 position)
        {
            // create a Prefab instance and get the product component
            GameObject instanceBase = Instantiate(bramblePrefab.gameObject, position, Quaternion.identity);
            Bramble bramble = instanceBase.GetComponent<Bramble>();

            // each product contains its own logic
            bramble.Initialize();

            return bramble;
        }
    }
}
