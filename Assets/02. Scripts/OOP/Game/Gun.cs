using UnityEngine;

public class Gun : MonoBehaviour, IDropItem
{
    public void Get()
    {
        Debug.Log("Gun is picked up!");
    }
    public void Use()
    {
        Debug.Log("Gun is fired!");
    }
    public void Drop()
    {
        Debug.Log("Gun is dropped!");
    }
}