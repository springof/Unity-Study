using UnityEngine;

public class Movement2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    private int jumpCount = 0;
    public float jumpForce = 5f;
    public SpriteRenderer[] renderers;
    private Rigidbody2D characterRb;
    private float h;
    private bool isGround;

    void Start()
    {
        characterRb = GetComponent<Rigidbody2D>();
        renderers = GetComponentsInChildren<SpriteRenderer>(true);
    }
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        Jump();
    }
    void FixedUpdate()
    {
        Move();
        OnSprite();
    }

    private void Move()
    {
        characterRb.linearVelocityX = h * moveSpeed;

        if (h > 0)
        {
            foreach (var renderer in renderers)
            {
                renderer.flipX = false; // 오른쪽으로 이동 시 스프라이트를 오른쪽으로 뒤집음
            }
        }
        else if (h < 0)
        {
            foreach (var renderer in renderers)
            {
                renderer.flipX = true; // 왼쪽으로 이동 시 스프라이트를 왼쪽으로 뒤집음
            }
        }
    }
    // 스프라이트 렌더러의 활성화 상태를 변경하여 스프라이트를 전환
    private void OnSprite()
    {
        renderers[0].gameObject.SetActive(h == 0 && isGround); // 스프라이트가 움직이지 않을 때만 활성화
        renderers[1].gameObject.SetActive(h != 0 && isGround); // 스프라이트가 움직일 때만 활성화
        renderers[2].gameObject.SetActive(!isGround); // 스프라이트가 공중에 있을 때만 활성화
    }
    // 2단 점프 기능 구현
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && jumpCount <= 1)
        {
            // Rigidbody2D 컴포넌트의 AddForce 메서드를 사용하여 점프
            characterRb.AddForceY(jumpForce, ForceMode2D.Impulse); // 점프 시 땅에 있지 않음
            jumpCount++;  
        }
    }
    // 땅에 닿으면 점프 횟수 초기화
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
            isGround = true;
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
