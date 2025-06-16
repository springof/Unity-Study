using UnityEngine;

public abstract class Monster : MonoBehaviour, IDamageable
{
    public float hp;

    public abstract void SetHealth();

    public void TakeDamage(float damage)
    {
        hp -= damage;
        Debug.Log("Monster took damage: " + damage + ", remaining health: " + hp);

        if (hp <= 0)
        {
            Death();
        }
    }
    private void Death()
    {
        Debug.Log("Monster died.");
        // Add death logic here, such as playing an animation or destroying the object
        Destroy(gameObject);
    }
}
