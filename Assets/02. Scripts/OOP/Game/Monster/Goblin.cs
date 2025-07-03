using System.Collections;
using System.Threading;
using UnityEngine;
using static MonsterCore;

public class Goblin : MonsterCore
{
    private float timer;
    private float idleTime, patrolTime;

    private float traceDist = 5f;
    private float attackDist = 1.5f;

    private bool isAttack;

    private void Start()
    {
        Init(20f, 2f, 3f, 3f);

        StartCoroutine(FindPlayerRoutine());
    }

    protected override void Init(float hp, float speed, float atkDamage, float atkCoolTime)
    {
        base.Init(hp, speed, atkDamage, atkCoolTime);

        idleTime = Random.Range(1f, 4f);
    }

    IEnumerator FindPlayerRoutine()
    {
        while (true)
        {
            yield return null;
            targetDist = Vector2.Distance(transform.position, target.position);

            if (monsterState == MonsterState.IDLE || monsterState == MonsterState.PATROL)
            {
                Vector3 monsterDir = Vector3.right * moveDir; // 몬스터가 바라보는 방향
                Vector3 playerDir = (transform.position - target.position).normalized; // 플레이어로부터 몬스터의 방향

                float dotValue = Vector3.Dot(monsterDir, playerDir); // 방향의 내적값

                isTrace = dotValue < -0.5f && dotValue >= -1f;

                if (targetDist <= traceDist && isTrace)
                {
                    animator.SetBool("isRun", true);
                    ChangeState(MonsterState.TRACE);
                }
            }
            // 몬스터가 플레이어를 바라보고 있는지 확인 음수가 나오면 플레이어를 바라보고 있는 것
            else if (monsterState == MonsterState.TRACE)
            {
                if (targetDist > traceDist)
                {
                    timer = 0f;
                    idleTime = Random.Range(1f, 4f);
                    animator.SetBool("isRun", false);

                    ChangeState(MonsterState.IDLE);

                }

                if (targetDist < attackDist)
                {
                    ChangeState(MonsterState.ATTACK);
                }
            }
        }
    }

    public override void Idle()
    {
        timer += Time.deltaTime;
        if (timer >= idleTime)
        {
            timer = 0f;
            moveDir = Random.Range(0, 2) == 1 ? 1 : -1;
            transform.localScale = new Vector3(moveDir, 1, 1);
            hpBar.transform.localScale = new Vector3(moveDir, 1, 1);

            patrolTime = Random.Range(2f, 5f);
            animator.SetBool("isRun", true);

            ChangeState(MonsterState.PATROL);
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
    }

    public override void Trace()
    {
        var targetDir = (target.position - transform.position).normalized;

        transform.position += Vector3.right * targetDir.x * speed * Time.deltaTime;

        var scaleX = targetDir.x > 0 ? 1 : -1;
        transform.localScale = new Vector3(scaleX, 1, 1);
        hpBar.transform.localScale = new Vector3(scaleX, 1, 1);
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
        float currAnimLength = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(currAnimLength);

        animator.SetBool("isRun", false);
        var targetDir = (target.position - transform.position).normalized;
        var scaleX = targetDir.x > 0 ? 1 : -1;
        transform.localScale = new Vector3(scaleX, 1, 1);
        hpBar.transform.localScale = new Vector3(scaleX, 1, 1);
        yield return new WaitForSeconds(atkCoolTime - 1f); // 공격 애니메이션 시간 동안 대기

        isAttack = false;
        animator.SetBool("isRun", true);
        ChangeState(MonsterState.TRACE);
    }
}