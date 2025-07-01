using Mono.Cecil;
using UnityEngine;

public abstract class MonsterCore : MonoBehaviour
{
    public enum MonsterState { IDLE, PATROL, TRACE, ATTACK }
    private MonsterState monsterState = MonsterState.IDLE;

    protected Animator animator;
    protected Rigidbody2D monsterRb;
    protected Collider2D monsterColl;

    public Transform target;

    public float hp;
    public float speed;
    protected float moveDir;
    protected bool isTrace;

    protected float targetDist;

    protected virtual void Init(float hp, float speed)
    {
        this.hp = hp;
        this.speed = speed;

        target = GameObject.FindGameObjectWithTag("Player").transform;

        animator = GetComponent<Animator>();
        monsterRb = GetComponent<Rigidbody2D>();
        monsterColl = GetComponent<Collider2D>();
    }

    private void Update()
    {
        targetDist = Vector2.Distance(transform.position, target.position);

        Vector3 monsterDir = Vector3.right * moveDir; // 몬스터가 바라보는 방향
        Vector3 playerDir = (transform.position - target.position).normalized; // 플레이어로부터 몬스터의 방향

        float dotValue = Vector3.Dot(monsterDir, playerDir); // 방향의 내적값

        isTrace = dotValue < -0.7f && dotValue >= -1f;
        // 몬스터가 플레이어를 바라보고 있는지 확인 음수가 나오면 플레이어를 바라보고 있는 것

        switch (monsterState)
        {
            case MonsterState.IDLE:
                Idle();
                break;
            case MonsterState.PATROL:
                Patrol();
                break;
            case MonsterState.TRACE:
                Trace();
                break;
            case MonsterState.ATTACK:
                Attack();
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Return"))
        {
            moveDir *= -1;
            transform.localScale = new Vector3(moveDir, 1, 1);
        }
    }

    public abstract void Idle();
    public abstract void Patrol();
    public abstract void Trace();
    public abstract void Attack();

    public void ChangeState(MonsterState newState)
    {
        if (monsterState != newState)
            monsterState = newState;
    }
}
