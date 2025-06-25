using UnityEngine;
using UnityEngine.UI;

public class KnightController_Joystick : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D knightRb;

    [SerializeField] private Button jumpButton;
    [SerializeField] private Button atkButton;

    private bool isGround;
    private bool isAttack;
    private bool isCombo;

    private float atkDamage = 3f;

    private Vector3 inputDir;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpForce = 15f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        knightRb = GetComponent<Rigidbody2D>();

        jumpButton.onClick.AddListener(Jump);
        atkButton.onClick.AddListener(Attack);
    }

    public void InputJoystick(float x, float y)
    {
        inputDir = new Vector3(x, y, 0).normalized;

        animator.SetFloat("JoystickX", inputDir.x);
        animator.SetFloat("JoystickY", inputDir.y);

        if (inputDir.x != 0)
        {
            var scaleX = inputDir.x < 0 ? -1 : 1;
            transform.localScale = new Vector3(scaleX, 1, 1);
        }
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
        if (isGround)
        {
            animator.SetTrigger("Jump");
            knightRb.AddForceY(jumpForce, ForceMode2D.Impulse);
        }
    }

    void Attack()
    {
        if (!isAttack)
        {
            isAttack = true;
            atkDamage = 3f;
            animator.SetTrigger("Attack");
        }
        else
        {
            isCombo = true;
        }
    }

    public void WaitCombo()
    {
        if (isCombo)
        {
            animator.SetBool("isCombo", true);
            atkDamage = 5f;
            Debug.Log($"{atkDamage}로 공격");
        }
        else
        {
            isAttack = false;
            animator.SetBool("isCombo", false);
        }
    }

    public void EndCombo()
    {
        isAttack = false;
        isCombo = false;
        animator.SetBool("isCombo", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            Debug.Log($"{atkDamage}로 공격");
        }
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

    //void SetAnimation()
    //{
    //    if (inputDir.x != 0)
    //    {
    //        var scaleX = inputDir.x < 0 ? -1 : 1;
    //        transform.localScale = new Vector3(scaleX, 1, 1);

    //        animator.SetBool("isRun", true);
    //    }

    //    else if (inputDir.x == 0)
    //        animator.SetBool("isRun", false);
    //}
}
