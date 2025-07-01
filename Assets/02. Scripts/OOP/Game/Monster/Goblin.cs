using System.Collections;
using System.Threading;
using UnityEngine;

public class Goblin : MonsterCore
{
    private float timer = 0f;
    private float idleTime, patrolTime;
    private float traceDist = 5f;
    private float attackDist = 2f;
    private bool isAttack;

    private void Start()
    {
        Init(10f, 2f);
    }

    protected override void Init(float hp, float speed)
    {
        base.Init(hp, speed);
    }

    public override void Idle()
    {
        timer += Time.deltaTime;
        if (timer >= idleTime)
        {
            timer = 0f;
            moveDir = Random.Range(0, 2) == 1 ? 1 : -1;
            transform.localScale = new Vector3(moveDir, 1, 1);
            patrolTime = Random.Range(2f, 5f);
            animator.SetBool("isRun", true);

            ChangeState(MonsterState.PATROL);
        }

        if (targetDist <= traceDist && isTrace)
        {
            timer = 0f;
            ChangeState(MonsterState.TRACE);
            animator.SetBool("isRun", true);
        }
    }

    public override void Patrol()
    {
        transform.position += Vector3.right * moveDir * speed * Time.deltaTime;

        timer += Time.deltaTime;
        if (timer >= patrolTime)
        {
            timer = 0f;
            idleTime = Random.Range(2f, 3f);
            animator.SetBool("isRun", false);

            ChangeState(MonsterState.IDLE);
        }

        if (targetDist <= traceDist && isTrace)
        {
            timer = 0f;
            ChangeState(MonsterState.TRACE);
            animator.SetBool("isRun", true);
        }
    }

    public override void Trace()
    {
        animator.SetBool("isRun", true);
        var targetDir = (target.position - transform.position).normalized;

        transform.position += Vector3.right * targetDir.x * speed * Time.deltaTime;

        var scaleX = targetDir.x > 0 ? 1 : -1;
        transform.localScale = new Vector3(scaleX, 1, 1);

        if (targetDist > traceDist)
        {
            animator.SetBool("isRun", false);

            ChangeState(MonsterState.IDLE);
        }

        if (targetDist <= attackDist)
        {
            animator.SetBool("isRun", false);
            ChangeState(MonsterState.ATTACK);
        }
    }

    public override void Attack()
    {
        if (!isAttack)
            StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        isAttack = true;
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(1f);

        isAttack = false;
        ChangeState(MonsterState.IDLE);
    }
}