using System.Collections.Generic;

namespace PlanetarySystem.Packages.Scripts.Runtime.PlanetarySystem.Architecture
{
    public interface IPlanetarySystem
    {
        public IEnumerable<IPlanetaryObject> planeteryObjects { get; set; }

        public void Update(float deltaTime);
    }
}