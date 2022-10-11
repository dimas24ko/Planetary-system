using System;
using System.Collections.Generic;
using UnityEngine.Rendering;

namespace PlanetarySystem.Packages.Scripts.Runtime.Planet
{
    [Serializable]
    public class PlanetsMap : SerializedDictionary<PlanetType, PlanetInfo> { }
}