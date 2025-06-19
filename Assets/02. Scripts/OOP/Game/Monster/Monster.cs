using System.Collections;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    public SpawnManager spawnManager;

    private SpriteRenderer sRenderer;
    private Animator animator;

    [SerializeField] protected float hp = 3f;
    protected float moveSpeed = 3f;
    private int dir = 1;
    private bool isMove = true;
    private bool isHit;

    public abstract void Init();

    private void Start()
    {
        spawnManager = FindFirstObjectByType<SpawnManager>();
        sRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        Init();
    }

    private void OnMouseDown()
    {
        StartCoroutine(Hit(1));
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!isMove) return;

        transform.position += Vector3.right * dir * moveSpeed * Time.deltaTime;

        if (transform.position.x > 8f)
        {
            dir = -1; // Change direction to left
            sRenderer.flipX = true; // Flip the sprite to face left
        }
        else if (transform.position.x < -8f)
        {
            dir = 1; // Change direction to right
            sRenderer.flipX = false; // Flip the sprite to face right
        }
    }

    public IEnumerator Hit(float damage)
    {
        if (isHit) yield break; // Prevent multiple hits at the same time
        isHit = true;
        isMove = false; // Stop moving when hit

        hp -= damage;

        if (hp <= 0)
        {
            animator.SetTrigger("Death");
            spawnManager.DropCoin(transform.position); // Drop a coin at the monster's position

            yield return new WaitForSeconds(3f); // Wait for the death animation to finish
            Destroy(gameObject); // Destroy the monster after death

            yield break;

        }
        animator.SetTrigger("Hit");

        yield return new WaitForSeconds(0.65f); // Wait for the hit animation to finish
        isHit = false; // Reset hit state
        isMove = true; // Resume moving after hit
    }
}