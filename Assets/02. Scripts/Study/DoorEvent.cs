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
        animator.SetTrigger("Open");
    }

    void OnTriggerExit(Collider collision)
    {
        animator.SetTrigger("Close");
    }
}
