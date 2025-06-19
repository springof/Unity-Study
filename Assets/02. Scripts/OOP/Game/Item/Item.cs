using UnityEngine;

public class Item : MonoBehaviour, IItem
{
    private Inventory inventory;

    public enum ItemType { Coin, GoldCoin, Chest }
    public ItemType itemType;

    public float gold;


    void Start()
    {
        inventory = FindFirstObjectByType<Inventory>();
        Obj = gameObject;
    }

    public GameObject Obj { get; set; }

    void OnMouseDown()
    {
        Get();
    }
            
    public void Get()
    {
        Debug.Log($"{this.name}을 획들했습니다.");

        inventory.AddItem(this);

        gameObject.SetActive(false);
    }
}
