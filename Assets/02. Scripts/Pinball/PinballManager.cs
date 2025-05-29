using UnityEngine;

public class PinballManager : MonoBehaviour
{
    public Rigidbody2D leftBarRb;
    public Rigidbody2D rightBarRb;
    public int score = 0;

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            // 왼쪽 바를 회전시키는 코드
            leftBarRb.AddTorque(30f);
        else
            leftBarRb.AddTorque(-25f); // 왼쪽 바를 원래 위치로 돌리는 코드
        if (Input.GetKey(KeyCode.RightArrow))
            // 오른쪽 바를 회전시키는 코드
            rightBarRb.AddTorque(-30f);
        else
            rightBarRb.AddTorque(25f); // 오른쪽 바를 원래 위치로 돌리는 코드
    }
}
