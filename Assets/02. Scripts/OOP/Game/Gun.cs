using UnityEngine;

public class Gun : MonoBehaviour, IDropItem
{
    public GameObject bulletPrefab; // Prefab for the bullet
    public Transform shootPos;

    public void Grab(Transform grabPos)
    {
        transform.SetParent(grabPos); // Set parent to grab position
        transform.localPosition = Vector3.zero; // Reset local position
        transform.localRotation = Quaternion.identity; // Reset local rotation
    }
    public void Use()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPos.position, Quaternion.identity);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        bulletRb.AddForce(shootPos.forward * 50f, ForceMode.Impulse);
    }
    public void Drop()
    {
        transform.SetParent(null); // Remove parent to drop the item
        transform.position = Vector3.zero;
    }
}