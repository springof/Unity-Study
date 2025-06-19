using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();

    public void AddItem(IItem item)
    {
        items.Add(item.Obj);
        Debug.Log($"{item.Obj.name}이(가) 인벤토리에 추가되었습니다. 현재 아이템 수: {items.Count}");
    }
}
