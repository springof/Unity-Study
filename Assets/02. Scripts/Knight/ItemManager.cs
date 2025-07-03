using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public GameObject inventoryUI; // 인벤토리 UI 패널
    public Button inventoryButton; // 인벤토리 버튼

    [SerializeField] private GameObject[] items;

    [SerializeField] private Transform slotGroup;
    public Slot[] slots; // 인벤토리 슬롯 배열

    private void Start()
    {
        slots = slotGroup.GetComponentsInChildren<Slot>(true); // 슬롯 그룹에서 모든 슬롯 컴포넌트를 가져옴

        inventoryButton.onClick.AddListener(OnInventory); // 인벤토리 버튼 클릭 시 OnInventory() 실행

        // 인벤토리 UI를 비활성화 상태로 시작
        inventoryUI.SetActive(false);
    }

    public void OnInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf); // 인벤토리 UI 활성화/비활성화
    }

    public void DropItem(Vector3 dropPos)
    {
        var randomIndex = Random.Range(0, items.Length);
        // 아이템을 위로 튀고 다시 떨어지게 하는 기능
        GameObject item = Instantiate(items[randomIndex], dropPos, Quaternion.identity);

        Rigidbody2D itemRb = item.GetComponent<Rigidbody2D>();

        itemRb.AddForceX(Random.Range(-1f, 1f), ForceMode2D.Impulse);
        itemRb.AddForceY(3f, ForceMode2D.Impulse);

        float ranPower = Random.Range(-1f, 1f);
        itemRb.AddTorque(ranPower, ForceMode2D.Impulse);
    }

    public void GetItem(IItemObject item)
    {
        // 인벤토리에 아이템 수납
        // 아이템이 들어갈 빈 슬롯을 찾는다 > AddItem() 실행
        foreach (var slot in slots)
        {
            if (slot.isEmpty)
            {
                slot.AddItem(item);
                break; // 찾으면 반복문 종료
            }
        }
    }
}
