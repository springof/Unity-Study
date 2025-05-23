using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        /// Input System
        /// �̵� > WASD, ����Ű
        /// ���� > Space
        /// �߻� > ���콺 Ŭ��
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //Vector3 dir = new Vector3(h, 0, v);
        //Debug.Log($"���� �Է� : {dir}");

        //transform.position += dir * moveSpeed * Time.deltaTime;

        Vector3 dir = new Vector3(h, 0, v);
        Vector3 normalDir = dir.normalized;

        transform.position += normalDir * moveSpeed * Time.deltaTime;

        transform.LookAt(transform.position + normalDir);
    }
}
