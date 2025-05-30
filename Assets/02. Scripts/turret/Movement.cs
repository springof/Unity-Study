using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public static int coinCount = 0;

    void Update()
    {
        /// Input System
        /// 이동 > WASD, 방향키
        /// 점프 > Space
        /// 발사 > 마우스 클릭
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //Vector3 dir = new Vector3(h, 0, v);
        //Debug.Log($"현재 입력 : {dir}");

        //transform.position += dir * moveSpeed * Time.deltaTime;

        Vector3 dir = new Vector3(h, 0, v);
        Vector3 normalDir = dir.normalized;

        transform.position += normalDir * moveSpeed * Time.deltaTime;

        transform.LookAt(transform.position + normalDir);
    }
    
}
