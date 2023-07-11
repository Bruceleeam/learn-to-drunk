using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Factory
{
    // a common interface between products
    public interface IProduct
    {
        // add common properties and methods here
        public string ProductName { get; set; }
        public List<GameObject> Bases { get; }
        public List<GameObject> Flavorings { get; }
        public List<GameObject> Decorations { get; }
        public List<GameObject> Dyes { get; }

        public int GetBasesNr();
        public int GetFlavoringsNr();
        public int GetDecorationsNr();
        public int GetDyesNr();

        // customize this for each concrete product
        public void Initialize();
    }
}
