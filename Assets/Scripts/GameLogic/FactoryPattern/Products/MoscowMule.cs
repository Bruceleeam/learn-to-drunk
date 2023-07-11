using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Factory
{
    public class MoscowMule : MonoBehaviour, IProduct
    {
        [SerializeField] private string productName = "Moscow Mule";
        [SerializeField] public List<GameObject> bases;
        [SerializeField] public List<GameObject> flavorings;
        [SerializeField] public List<GameObject> decorations;
        [SerializeField] public List<GameObject> dyes;

        public string ProductName { get => productName; set => productName = value ; }
        public List<GameObject> Bases { get => bases; }
        public List<GameObject> Flavorings { get => flavorings; }
        public List<GameObject> Decorations { get => decorations; }
        public List<GameObject> Dyes { get => dyes; }

        public void Initialize()
        {
            // any unique logic to this product
            gameObject.name = productName;
        }

        public int GetBasesNr()
        {
            return Bases.Count;
        }

        public int GetFlavoringsNr()
        {
            return Flavorings.Count;
        }

        public int GetDecorationNr()
        {
            return Decorations.Count;
        }

        public int GetDyesNr()
        {
            return Dyes.Count;
        }
    }
}
