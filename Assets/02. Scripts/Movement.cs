using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 10f;

    void Update()
    {
        //transform.position = transform.position + Vector3.forward * moveSpeed;

        if (Input.GetKey(KeyCode.W)) //앞
        {
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A)) //왼쪽
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S)) //뒤
        {
            transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)) //오른쪽
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
    }
}
