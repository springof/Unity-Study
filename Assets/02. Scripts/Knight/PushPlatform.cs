using UnityEngine;

public class PushPlatform : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D targetRb;

    private void Start()
    {
        animator = GetComponent<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            targetRb = other.GetComponent<Rigidbody2D>();
            Invoke("PushCharacter", 1f);
        }
    }

    void PushCharacter()
    {
        targetRb.AddForceY(35f, ForceMode2D.Impulse);
        animator.SetTrigger("Push");
    }
}

