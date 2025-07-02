using UnityEngine;

public interface IItemObject
{
    ItemManager Inventory { get; set; }

    GameObject Obj { get; set; }
    string ItemName { get; set; }
    Sprite Icon { get; set; }

    void Get();
    void Use();
}