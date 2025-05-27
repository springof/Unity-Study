using UnityEngine;

public class Transform_LoopMap : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float height;
    public Vector3 returnPos;
    void Start()
    {
        height = transform.position.y; // 현재 높이를 저장
        returnPos = new Vector3(30f, height, 0f); 
    }

    void Update()
    {
        //배경 왼쪽으로 이동
        //transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        transform.position += Vector3.left * moveSpeed * Time.fixedDeltaTime;

        //이미지가 왼쪽으로 이동하여 화면 밖으로 나갔을 때, 위치를 초기화
        if (transform.position.x <= -30f)
        {
            transform.position = returnPos;
        }
    }
}
