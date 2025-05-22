using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 10f;

    void Update()
    {
        /// Input System
        /// �̵� > WASD, ����Ű
        /// ���� > Space
        /// �߻� > ���콺 Ŭ��
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        Debug.Log($"���� �Է� : {dir}");

        transform.position += dir * moveSpeed * Time.deltaTime;
    }
}
