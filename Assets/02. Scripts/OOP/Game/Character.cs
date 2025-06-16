using UnityEngine;

public class Character : MonoBehaviour
{
    public IDropItem currentItem;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentItem != null)
            {
                currentItem.Use();
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currentItem != null)
            {
                currentItem.Drop();
                currentItem = null;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IDropItem>() != null)
        {
            IDropItem item = other.GetComponent<IDropItem>();

            item.Get();

            currentItem = item;
        }
    }
}