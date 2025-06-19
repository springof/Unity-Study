using UnityEngine;

public class Potion : MonoBehaviour, IItem
{
    private Inventory inventory;

    public enum PotionType { Health, Mana, Skill, HPMax }
    public PotionType potionType;

    public float Health;
    public float Mana;
    public float Skill;
    public float HPMax;


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
        Debug.Log($"{this.name}을 획득했습니다.");

        inventory.AddItem(this);

        gameObject.SetActive(false);
    }
}
