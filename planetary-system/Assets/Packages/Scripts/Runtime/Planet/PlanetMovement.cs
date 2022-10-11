using UnityEngine;

namespace PlanetarySystem.Packages.Scripts.Runtime.Planet
{
    public class PlanetMovement : MonoBehaviour
    {
        public void Update()
        {
            transform.RotateAround(Vector3.zero, Vector3.up, Random.Range(1, 25) * Time.deltaTime);
            transform.RotateAround(Vector3.up, Vector3.zero , Random.Range(5, 35) * Time.deltaTime);
            
            //ToDO add speed into data 
        }
    }
}