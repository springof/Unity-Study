using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public Transform targetPlanet; //The planet around which this planet revolves
    public float rotSpeed = 30f; //Rotation speed
    public float revSpeed = 100f; //Revolution speed
    public bool isRevolving = false; //Whether the planet is revolving around the target planet

    void Update()
    {

        transform.Rotate(Vector3.up, rotSpeed * Time.deltaTime); //Rotate the planet around its own axis
        
        if (isRevolving == true)
        {
            transform.RotateAround(targetPlanet.position, Vector3.up, revSpeed * Time.deltaTime); //Revolve the planet around the target planet
        }
    }
}
