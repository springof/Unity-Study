using UnityEngine;

public class DoorEvent : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
            animator.SetTrigger("Open");
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
            animator.SetTrigger("Close");
    }
}
