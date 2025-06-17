using UnityEngine;

public interface IDropItem
{
    void Grab(Transform grabPos);
    void Use();
    void Drop();
}