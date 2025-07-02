using System;
using UnityEngine;
using UnityEngine.InputSystem.Processors;
using UnityEngine.UI;

public class KnightController_Keyboard : MonoBehaviour, IDamageable
{
    private Animator animator;
    private Rigidbody2D knightRb;
    private Collider2D knightColl;
    [SerializeField] private Image hpBar;

    private Vector3 inputDir;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private GameObject jewel;

    private bool isGround;
    private bool isAttack;
    private bool isCombo;
    private bool isLadder;

    public float hp = 100f; // Knight's health points
    public float currHp;

    private float atkDamage = 3f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        knightRb = GetComponent<Rigidbody2D>();
        knightColl = GetComponent<Collider2D>();

        currHp = hp;
        hpBar.fillAmount = currHp / hp;
    }

    void Update()
    {
        InputKeyboard();
        Jump();
        Attack();
    }

    void FixedUpdate()
    {
        Move();
    }

    void InputKeyboard()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        inputDir = new Vector3(h, v, 0);

        animator.SetFloat("JoystickX", inputDir.x);
        animator.SetFloat("JoystickY", inputDir.y);

        if (inputDir.y < 0)
        {
            GetComponent<CapsuleCollider2D>().size = new Vector2(0.9f, 1.4f);
            GetComponent<CapsuleCollider2D>().offset = new Vector2(0f, 0.7f);
        }
        else
        {
            GetComponent<CapsuleCollider2D>().size = new Vector2(0.9f, 1.9f);
            GetComponent<CapsuleCollider2D>().offset = new Vector2(0f, 0.95f);
        }

    }

    void Move()
    {
        if (inputDir.x != 0)
        {
            var scaleX = inputDir.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(scaleX, 1, 1);

            knightRb.linearVelocityX = inputDir.x * moveSpeed;
        }

        if (isLadder && inputDir.y != 0)
        {
            knightRb.linearVelocityY = inputDir.y * moveSpeed;
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            animator.SetTrigger("Jump");
            knightRb.AddForceY(jumpForce, ForceMode2D.Impulse);
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.X))
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            Debug.Log($"{atkDamage}의 데미지를 입힘");
        }
        if (other.CompareTag("Ladder"))
        {
            isLadder = true;
            knightRb.gravityScale = 0f; // Disable gravity when on ladder
            knightRb.linearVelocity = Vector2.zero;
        }
        if (other.CompareTag("Jewel"))
        {
            Debug.Log("보석을 획득했다.");
            jewel.SetActive(false); // Deactivate jewel object
        }
        if (other.CompareTag("JewelBox"))
        {
            Debug.Log("보석을 내려놓았다.");
            MovingPlatform.isOn = true; // Activate moving platform
        }

        if (other.CompareTag("Monster"))
        {
            if (other.GetComponent<IDamageable>() != null)
            {
                other.GetComponent<IDamageable>().TakeDamage(atkDamage);
                other.GetComponent<Animator>().SetTrigger("Hit");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isLadder = false;
            knightRb.gravityScale = 2f; // Re-enable gravity when off ladder
            knightRb.linearVelocity = Vector2.zero;
        }
    }

    public void TakeDamage(float damage)
    {
        currHp -= damage;

        hpBar.fillAmount = currHp / hp;

        if (currHp <= 0)
            Death();
    }

    public void Death()
    {
        Debug.Log("Knight has died.");
        animator.SetTrigger("Death");
        knightColl.enabled = false; // Disable collider on death
        knightRb.gravityScale = 0f; // Disable gravity on death
    }
}
