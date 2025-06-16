using UnityEngine;

public class TownPerson : MonoBehaviour, IMove, ITalk
{
    public float moveSpeed;
    public void Move()
    {
        Debug.Log("TownPerson is moving at speed: " + moveSpeed);
        transform.position += transform.right * moveSpeed * Time.deltaTime;
    }
    public void Talk()
    {
        Debug.Log("TownPerson is attacking!");
    }
}