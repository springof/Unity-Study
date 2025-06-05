using UnityEngine;
using Cat;

public class CatController : MonoBehaviour
{
    public SoundManager soundManager;
    public GameObject fadeUI;
    private Rigidbody2D catRb;
    private Animator catAnim;
    public float jumpPorce = 10f;
    public float limitPower = 5f; // 점프 속도 제한
    public static float catHealth = 100f;
    public bool isGround = false;
    public int jumpCount = 0; // 점프 쿨타임

    void Start()
    {
        catRb = GetComponent<Rigidbody2D>();
        catAnim = GetComponent<Animator>();
    }

    void Update()
    {
        // 키 입력 받기
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            catAnim.SetTrigger("Jump"); // 점프 애니메이션 트리거
            catAnim.SetBool("Fall", false); // 점프 애니메이션 시작 시 Fall 상태 해제
            //점프 = y축 방향으로 이동 X
            catRb.AddForceY(jumpPorce, ForceMode2D.Impulse);
            soundManager.OnJumpSound(); // 점프 사운드 재생
            jumpCount++;

            if (catRb.linearVelocityY > limitPower)
                catRb.linearVelocityY = limitPower; // 점프 속도 제한
        }

        if (transform.position.y < -5f || catHealth <= 0f)
        {
            // y축 위치가 -5보다 작으면 게임 오버
            Debug.Log("Game Over");
            fadeUI.SetActive(true); // 게임 오버 UI 활성화
            catAnim.SetTrigger("GameOver"); // 게임 오버 애니메이션 트리거
            // 게임 오버 처리 로직 추가
            // 예: 게임 오버 UI 표시, 재시작 버튼 활성화 등
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            catAnim.SetBool("Fall", true);
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
