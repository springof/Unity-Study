using UnityEngine;

public class DoorEvent : MonoBehaviour
{
    private Animator anim;

    public GameObject doorLock;

    public string openKey;
    public string closeKey;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            doorLock.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
            doorLock.SetActive(false);
    }
}
