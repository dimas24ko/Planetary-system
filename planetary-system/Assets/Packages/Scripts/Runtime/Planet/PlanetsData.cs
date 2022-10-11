using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetarySystem.Packages.Scripts.Runtime.Planet
{
    [CreateAssetMenu(fileName = "PlanetsData", menuName = "Planets")]
    public class PlanetsData : ScriptableObject
    {
        [field: SerializeField] public PlanetsMap PlanetsMap;
    }
}