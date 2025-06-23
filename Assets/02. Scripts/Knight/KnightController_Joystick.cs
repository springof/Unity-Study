using UnityEngine;

public class KnightController_Joystick : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D knightRb;

    private bool isGround;

    private Vector3 inputDir;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpForce = 15f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        knightRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
 
    }

    void FixedUpdate()
    {
        Move();
    }


    void Move()
    {
        if (inputDir.x != 0)
            knightRb.linearVelocityX = inputDir.x * moveSpeed;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            animator.SetTrigger("Jump");
            knightRb.AddForceY(jumpForce, ForceMode2D.Impulse);
        }
    }

    void SetAnimation()
    {
        if (inputDir.x != 0)
        {
            var scaleX = inputDir.x < 0 ? -1 : 1;
            transform.localScale = new Vector3(scaleX, 1, 1);

            animator.SetBool("isRun", true);
        }

        else if (inputDir.x == 0)
            animator.SetBool("isRun", false);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isGround", true);
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isGround", false);
            isGround = false;
        }
    }
}
