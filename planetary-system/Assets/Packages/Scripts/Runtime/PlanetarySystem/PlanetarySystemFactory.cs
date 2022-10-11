using System;
using System.Collections.Generic;
using System.Linq;
using PlanetarySystem.Packages.Scripts.Runtime.Planet;
using PlanetarySystem.Packages.Scripts.Runtime.PlanetarySystem.Architecture;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PlanetarySystem.Packages.Scripts.Runtime.PlanetarySystem
{
    public class PlanetarySystemFactory : MonoBehaviour, IPlanetarySystemFactory
    {
        private const float MinRadiusMultiplier = 2f;
        private const float MaxRadiusMultiplier = 5f;
        
        public PlanetsData Data;
        
        public GameObject PlanetPrefab;

        public float PlanetarySystemMass;

        private IPlanetarySystem system;

        private List<PlanetType> PlanetTypes => Enum.GetValues(typeof(PlanetType)).Cast<PlanetType>().ToList();

        private PlanetsMap planetsMap => Data.PlanetsMap;

        private void Awake() => 
            Create(PlanetarySystemMass);

        public IPlanetarySystem Create(float mass)
        {
            system = new PlanetarySystem();
            system.planeteryObjects = new List<IPlanetaryObject>();

            while (mass > 0.1)
            {
                var newPlanetType = PlanetTypes[Random.Range(0, PlanetTypes.Count)];

                if (!(planetsMap[newPlanetType].Masses.MinMass < mass))
                    continue;

                var newPlanetMass = CalculateObjectMass(newPlanetType, mass);

                var newPlanetObject = InstantiatePlanet(newPlanetMass, newPlanetType);

                system.planeteryObjects.ToList().Add(newPlanetObject);

                mass -= newPlanetMass;
            }

            PlanetPrefab.SetActive(false);
            
            return system;
        }
        
        private IPlanetaryObject InstantiatePlanet(float mass, PlanetType type)
        {
            var newPlanet = Instantiate(PlanetPrefab, Vector3.zero, Quaternion.identity);
            var planetaryObject = newPlanet.GetComponent<PlanetaryObject>();

            planetaryObject.Type = type;
            planetaryObject.Mass = mass;
            
            SetupScale(newPlanet, planetaryObject.Mass);            
            
            planetaryObject.Radius = SetupOrbitRadius(newPlanet);
            
            SetupColor(planetaryObject);
            
            return planetaryObject;
        }

        private float CalculateObjectMass(PlanetType type, float mass)
        {
            var planetMasses = planetsMap[type].Masses;

            return Random.Range(planetMasses.MinMass, planetMasses.MaxMass < mass 
                ? planetMasses.MaxMass 
                : mass);
        }

        private void SetupColor(PlanetaryObject planet) =>
            planet.Render.material = new Material(planet.Render.material) { color = Random.ColorHSV() };

        private float SetupOrbitRadius(GameObject planet) =>
            !system.planeteryObjects.ToList().Any() 
                ? SetFirstOrbit(planet) 
                : DefaultSetOrbit(planet);

        private float DefaultSetOrbit(GameObject planet)
        {
            var radius = system.planeteryObjects.ToList().Last().Radius + system.planeteryObjects.ToList().Last().Mass + planet.GetComponent<Renderer>().bounds.size.x * Random.Range(MinRadiusMultiplier, MaxRadiusMultiplier);
            var randomPosition = Vector3.one * radius;

            planet.transform.position = new Vector3(randomPosition.x, 0, randomPosition.y);
            
            return radius;
        }

        private float SetFirstOrbit(GameObject planet)
        {
            var radius = planet.GetComponent<Renderer>().bounds.size.x * Random.Range(MinRadiusMultiplier, MaxRadiusMultiplier);
            Vector3 randomPosition = Random.insideUnitCircle * radius;

            planet.transform.position = new Vector3(randomPosition.x, 0, randomPosition.y);
            return radius;
        }

        private void SetupScale(GameObject planet, float planetaryMass) => 
            planet.transform.localScale = Vector3.one * planetaryMass;
    }
}