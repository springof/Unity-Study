using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] monsters;

    [SerializeField] private GameObject[] items;

    // n초마다 몬스터를 랜덤으로 생성

    IEnumerator Start()
    {
        while (true)
        {
            //몬스터를 생성하는 기능
            yield return new WaitForSeconds(3f); // 3초마다 몬스터 생성

            var randomIndex = Random.Range(0, monsters.Length);
            var randomX = Random.Range(-8f, 8f);
            var randomY = Random.Range(-4f, 4f);

            var createPos = new Vector3(randomX, randomY, 0f);

            Instantiate(monsters[randomIndex], createPos, Quaternion.identity);
        }
    }

    public void DropCoin(Vector3 dropPos)
    {
        var randomIndex = Random.Range(0, items.Length);
        //아이템을 위로 튀고 다시 떨어지게 하는 기능
        GameObject item = Instantiate(items[randomIndex], dropPos, Quaternion.identity);

        Rigidbody2D itemRb = item.GetComponent<Rigidbody2D>();

        itemRb.AddForceY(3f, ForceMode2D.Impulse);
        itemRb.AddForceX(Random.Range(-1f, 1f), ForceMode2D.Impulse);

        float ranPower = Random.Range(-1f, 1f);
        itemRb.AddTorque(ranPower, ForceMode2D.Impulse); // Add some random rotation to the item
    }
}
