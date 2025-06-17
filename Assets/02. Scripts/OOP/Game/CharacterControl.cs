using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private IDropItem currentItem;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform grabPos;

    private void Update()
    {
        Move(); //캐릭터 이동
        Interaction(); //아이템 상호작용
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal"); //x축 가로값(좌, 우)
        float v = Input.GetAxis("Vertical"); //z축 세로값(앞, 뒤)

        Vector3 dir = new Vector3(h, 0, v).normalized;

        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    private void Interaction()
    {
        if (currentItem == null) return; //아이템이 없으면 상호작용 불가

        if (Input.GetMouseButtonDown(0))
        {
            currentItem.Use(); //아이템 사용
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentItem.Drop(); //아이템 버리기
            currentItem = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IDropItem>() != null)
        {
            var item = other.GetComponent<IDropItem>();
            currentItem = item;

            item.Grab(grabPos); //아이템 획득
        }
    }
}
