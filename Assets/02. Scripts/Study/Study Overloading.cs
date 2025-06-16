using UnityEngine;

//Player
public class StudyOverloading : MonoBehaviour
{
    void Start()
    {
        Attack(true);
        Attack(10.0f);
        GameObject gameObject = new GameObject("몬스터");
        Attack(10.0f, gameObject);
    }

    public void Attack()
    {

    }

    public void Attack(bool isMagic)
    {
        if (isMagic)
            Debug.Log("마법 공격!");
        else
            Debug.Log("물리 공격!");
    }

    public void Attack(float damage)
    {
        Debug.Log($"{damage} 데미지 공격!");
    }

    public void Attack(float damage, GameObject target)
    {
        Debug.Log($"{target.name}에게 {damage} 데미지 공격!");
    }
}
