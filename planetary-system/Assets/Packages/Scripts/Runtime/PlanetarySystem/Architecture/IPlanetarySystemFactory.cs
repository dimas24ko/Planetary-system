namespace PlanetarySystem.Packages.Scripts.Runtime.PlanetarySystem.Architecture
{
    public interface IPlanetarySystemFactory
    {
        public IPlanetarySystem Create(float mass);
    }
}