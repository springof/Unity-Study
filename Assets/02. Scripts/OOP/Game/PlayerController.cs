using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private GameObject hitBox;

    [SerializeField] private float moveSpeed = 5f;
    private float h, v;
    private bool isAttacking = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Attack();
    }

    void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if (h == 0 && v == 0)
        {
            animator.SetBool("Run", false);
        }
        else
        {
            transform.localScale = new Vector3(h > 0 ? 1 : -1, 1, 1); // Flip the player sprite based on direction
            animator.SetBool("Run", true);

            var dir = new Vector3(h, v, 0).normalized;
            transform.position += moveSpeed * Time.deltaTime * dir;
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isAttacking)
        {
            StartCoroutine(AttackRoutine());
        }
    }

    IEnumerator AttackRoutine()
    {
        isAttacking = true;
        hitBox.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        hitBox.SetActive(false);
        isAttacking = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Monster>() != null)
        {
            Monster monster = other.GetComponent<Monster>();
            StartCoroutine(monster.Hit(1)); // Assuming Hit method is defined in Monster class
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<IItem>() != null)
        {
            IItem item = other.gameObject.GetComponent<IItem>();
            item.Get(); // Assuming Get method is defined in Item class
        }
    }
}
