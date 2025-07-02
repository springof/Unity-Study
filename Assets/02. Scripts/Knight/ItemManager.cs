using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private GameObject[] items;

    public void DropItem(Vector3 dropPos)
    {
        var randomIndex = Random.Range(0, items.Length);
        //아이템을 위로 튀고 다시 떨어지게 하는 기능
        GameObject item = Instantiate(items[randomIndex], dropPos, Quaternion.identity);

        Rigidbody2D itemRb = item.GetComponent<Rigidbody2D>();

        itemRb.AddForceX(Random.Range(-1f, 1f), ForceMode2D.Impulse);
        itemRb.AddForceY(3f, ForceMode2D.Impulse);

        float ranPower = Random.Range(-1f, 1f);
        itemRb.AddTorque(ranPower, ForceMode2D.Impulse);
    }

    public void GetItem(IItemObject item)
    {
        //인벤토리에 아이템 수납
    }
}
