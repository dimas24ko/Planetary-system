using PlanetarySystem.Packages.Scripts.Runtime.Planet;

namespace PlanetarySystem.Packages.Scripts.Runtime.PlanetarySystem.Architecture
{
    public interface IPlanetaryObject
    {
        public PlanetType Type
        {
            get;
            set;
        }

        public float Mass
        {
            get;
            set; 
        }
        
        public float Radius
        {
            get;
            set; 
        }
    }
}