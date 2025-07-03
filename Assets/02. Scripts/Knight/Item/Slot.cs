using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private IItemObject item; // 슬롯에 들어올 아이템
    private Image itemImage; // 먹은 아이템의 이미지가 들어갈 곳
    private Button slotButton; // 아이템 Use()를 하기 위한 버튼

    public bool isEmpty = true;

    private void Awake()
    {
        slotButton = GetComponent<Button>(); // 현재 슬롯의 버튼 컴포넌트 가져오기
        itemImage = transform.GetChild(0).GetComponent<Image>(); // 슬롯의 자식 이미지 컴포넌트 가져오기

        slotButton.onClick.AddListener(UseItem); // 버튼이 눌리면 UseItem() 실행
    }

    void OnEnable() // 인벤토리가 켜질 때 마다 1번 실행
    {
        //if (isEmpty)
        slotButton.interactable = !isEmpty; // 숏코드
        itemImage.gameObject.SetActive(!isEmpty);
    }

    public void AddItem(IItemObject newItem)
    {
        item = newItem;
        isEmpty = false;
        itemImage.sprite = newItem.Icon;
        itemImage.SetNativeSize();
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
            ClearSlot();
        }
    }

    public void ClearSlot()
    {
        item = null; // 슬롯의 아이템을 비움
        isEmpty = true; // 슬롯이 비어있음을 표시
        slotButton.interactable = !isEmpty; // 버튼 비활성화
        itemImage.gameObject.SetActive(!isEmpty); // 이미지 비활성화
    }
}
