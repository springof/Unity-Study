using UnityEngine;
using Cat;
using cat;
using System.Collections;

public class CatController : MonoBehaviour
{
    public SoundManager soundManager;
    public VideoManager videoManager;

    public GameObject gameOverUI;
    public GameObject fadeUI;

    private Rigidbody2D catRb;
    private Animator catAnim;

    public float jumpPorce = 15f;
    public float limitPower = 10f; // 점프 속도 제한
    public static float catHealth = 100f;
    public int jumpCount = 0; // 점프 횟수


    void Start()
    {
        catRb = GetComponent<Rigidbody2D>();
        catAnim = GetComponent<Animator>();
    }

    void Update()
    {
        // 키 입력 받기
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 3)
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
            GameManager.isPlay = false; // 게임 플레이 상태 해제
            gameOverUI.SetActive(true); // 게임 오버 UI 활성화
            fadeUI.SetActive(true); // 페이드 UI 활성화
            fadeUI.GetComponent<FadeRoutine>().OnFade(3f, Color.black); // 페이드 효과 적용
            this.GetComponent<CircleCollider2D>().enabled = false; // 충돌체 비활성화

            //Invoke("SadVideo", 5f); // 5초 후에 SadVideo 메소드 호출
            StartCoroutine(EndingRoutine(false)); // 게임 오버 루틴 시작
        }

        if (GameManager.score >= 15)
        {
            // 점수가 10점 이상이면 게임 승리
            GameManager.isPlay = false; // 게임 플레이 상태 해제
            fadeUI.SetActive(true); // 페이드 UI 활성화
            fadeUI.GetComponent<FadeRoutine>().OnFade(3f, Color.green); // 페이드 효과 적용
            this.GetComponent<CircleCollider2D>().enabled = false; // 충돌체 비활성화

            //Invoke("HappyVideo", 5f); // 5초 후에 HappyVideo 메소드 호출
            StartCoroutine(EndingRoutine(true)); // 게임 승리 루틴 시작
        }
    }

    IEnumerator EndingRoutine(bool isHappy)
    {
        yield return new WaitForSeconds(3.5f); // 5초 대기
        videoManager.VideoPlay(isHappy);

        //yield return new WaitUntil(() => videoManager.vPlayer.isPlaying);

        fadeUI.SetActive(false); // 페이드 UI 비활성화
        gameOverUI.SetActive(false); // 게임 오버 UI 비활성화
        soundManager.audioSource.mute = true; // 사운드 음소거
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cherry"))
        {
            other.gameObject.SetActive(false); // 체리 먹으면 비활성화
            other.transform.parent.GetComponent<ItemEvent>().particle.SetActive(true); // 파티클 효과 활성화
            GameManager.score++;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            catAnim.SetBool("Fall", true);
            jumpCount = 0; // 땅에 닿으면 점프 횟수 초기화
        }
        if (collision.gameObject.CompareTag("Pipe"))
        {
            soundManager.OnColliderSound(); // 충돌 사운드 재생
        }
    }
}
