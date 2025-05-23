using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 50f;

    void Update()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }
}
