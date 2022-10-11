using System.Collections.Generic;
using PlanetarySystem.Packages.Scripts.Runtime.PlanetarySystem.Architecture;

namespace PlanetarySystem.Packages.Scripts.Runtime.PlanetarySystem
{
    public class PlanetarySystem : IPlanetarySystem
    {
        public IEnumerable<IPlanetaryObject> planeteryObjects { get; set; }

        public void Update(float deltaTime) => 
            throw new System.NotImplementedException();
    }
}