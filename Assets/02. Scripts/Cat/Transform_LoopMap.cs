using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float returnPosX = 10f;
    public float randomPosY;
    //-5.5 ~ -1.1
    public Vector3 returnPos;

    void Update()
    {
        //배경 왼쪽으로 이동
        //transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        transform.position += Vector3.left * moveSpeed * Time.fixedDeltaTime;

        //이미지가 왼쪽으로 이동하여 화면 밖으로 나갔을 때, 위치를 초기화
        if (transform.position.x <= -returnPosX)
        {
            randomPosY = Random.Range(-5.5f, -1.1f); // y축 위치를 랜덤으로 설정
            transform.position = new Vector3(returnPosX, randomPosY, 1f);
        }
    }
}
