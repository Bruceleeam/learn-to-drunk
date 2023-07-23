using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

namespace DesignPatterns.Factory
{
    public class Creator : MonoBehaviour
    {
        [SerializeField] private LayerMask layerToClick;
        [SerializeField] private Vector3 offset;
        [SerializeField] List<Factory> factories;

        private Factory factory;

        public IProduct GetProduct(string destination)
        {
           return factories.Find(obj => obj.name == destination).GetBase(Vector3.zero + offset);
        }
    }
}

