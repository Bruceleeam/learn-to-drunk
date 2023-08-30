using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Factory
{
    public class Creator : MonoBehaviour
    {
        [SerializeField] List<Factory> factories;

        private Factory factory;

        public IProduct GetProduct(string destination)
        {
           return factories.Find(obj => obj.name == destination).GetProduct(Vector3.zero);
        }
    }
}

