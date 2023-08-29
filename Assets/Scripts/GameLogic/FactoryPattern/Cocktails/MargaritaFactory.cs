using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Factory
{
    public class MargaritaFactory : Factory
    {
        // used to create a Prefab
        [SerializeField] private Margarita margaritaPrefab;

        public override IProduct GetBase(Vector3 position)
        {
            // create a Prefab instance and get the product component
            GameObject instanceBase = Instantiate(margaritaPrefab.gameObject, position, Quaternion.identity);
            Margarita margarita = instanceBase.GetComponent<Margarita>();

            // each product contains its own logic
            margarita.Initialize();

            return margarita;
        }
    }
}
