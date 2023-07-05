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
        [SerializeField] Factory[] factories;

        private Factory factory;

        public IProduct GetProduct()
        {
           return factories[0].GetBase(Vector3.zero + offset);
        }
    }
}

