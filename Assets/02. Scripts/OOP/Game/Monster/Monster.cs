using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    private SpriteRenderer sRenderer;

    [SerializeField] protected float hp = 3f;
    protected float moveSpeed = 3f;
    private int dir = 1;

    public abstract void Init();

    private void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();

        Init();
    }

    private void OnMouseDown()
    {
        Hit(1);
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
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

    void Hit(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }

    }
}