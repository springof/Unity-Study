using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Player"))
        {
            Movement.coinCount++;
            Debug.Log($"Coin Count : {Movement.coinCount}");
            Destroy(gameObject);
        }
    }
}
