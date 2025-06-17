using UnityEngine;

public class FlashLight : MonoBehaviour, IDropItem
{
    public GameObject lightObj;
    public bool isLight = false;

    public void Grab(Transform grabPos)
    {
        transform.SetParent(grabPos); // Set parent to grab position
        transform.localPosition = Vector3.zero; // Reset local position
        transform.localRotation = Quaternion.identity; // Reset local rotation
    }
    public void Use()
    {
        isLight = !isLight;
        lightObj.SetActive(isLight);
    }
    public void Drop()
    {
        transform.SetParent(null); // Remove parent to drop the item
        transform.position = Vector3.zero;
    }
}