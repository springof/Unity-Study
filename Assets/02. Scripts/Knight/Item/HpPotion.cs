using UnityEngine;

public class HpPotion : MonoBehaviour, IItemObject
{
    public ItemManager Inventory { get; set; }
    public GameObject Obj { get; set; }
    public string ItemName { get; set; }
    public Sprite Icon { get; set; }

    void Start()
    {
        Inventory = FindFirstObjectByType<ItemManager>();

        Obj = gameObject;
        ItemName = name;
        Icon = GetComponent<SpriteRenderer>().sprite;
    }

    public void Get()
    {
        gameObject.SetActive(false);

        // 인벤토리 시스템 작동
        Inventory.GetItem(this);
    }
    public void Use()
    {
        Debug.Log("아이템 사용");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Get();
        }
    }
}