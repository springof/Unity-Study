using UnityEngine;

public class FlashLight : MonoBehaviour, IDropItem
{
    //public GameObject lightObj;
    //public bool isLight = false;
    public void Get()
    {
        Debug.Log("Flashlight is picked up!");
    }
    public void Use()
    {
        //isLight = !isLight;
        //lightObj.SetActive(isLight);
        Debug.Log("Flashlight is turned on!");
    }
    public void Drop()
    {
        Debug.Log("Flashlight is dropped!");
    }
}