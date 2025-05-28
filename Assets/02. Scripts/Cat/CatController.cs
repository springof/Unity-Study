using UnityEngine;

public class CatController : MonoBehaviour
{
    private Rigidbody2D catRb;
    public float jumpForce = 3f;
    public static float catHealth = 100f;
    public bool isGround = false;
    public int jumpCount = 0; // 점프 쿨타임

    void Start()
    {
        catRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 키 입력 받기
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            //점프 = y축 방향으로 이동 X
            catRb.AddForceY(jumpForce, ForceMode2D.Impulse);
            jumpCount++;
        }

        if (transform.position.y < -5f || catHealth <= 0f)
        {
            // y축 위치가 -5보다 작으면 게임 오버
            Debug.Log("Game Over");
            // 게임 오버 처리 로직 추가
            // 예: 게임 오버 UI 표시, 재시작 버튼 활성화 등
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            jumpCount = 0; // 땅에 닿으면 점프 카운트 초기화
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}
