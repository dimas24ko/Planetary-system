using PlanetarySystem.Packages.Scripts.Runtime.Planet;
using PlanetarySystem.Packages.Scripts.Runtime.PlanetarySystem.Architecture;
using UnityEngine;

namespace PlanetarySystem.Packages.Scripts.Runtime.PlanetarySystem
{
    public class PlanetaryObject : MonoBehaviour, IPlanetaryObject
    {
        public PlanetType Type { get; set; }
        public float Mass { get; set; }
        public float Radius { get; set; }

        public Renderer Render;
    }
}