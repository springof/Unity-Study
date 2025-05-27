using UnityEngine;

public class Transform_LoopMap : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float height;
    public Vector3 returnPos;
    void Start()
    {
        height = transform.position.y; // ���� ���̸� ����
        returnPos = new Vector3(30f, height, 0f); 
    }

    void Update()
    {
        //��� �������� �̵�
        //transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        transform.position += Vector3.left * moveSpeed * Time.fixedDeltaTime;

        //�̹����� �������� �̵��Ͽ� ȭ�� ������ ������ ��, ��ġ�� �ʱ�ȭ
        if (transform.position.x <= -30f)
        {
            transform.position = returnPos;
        }
    }
}
