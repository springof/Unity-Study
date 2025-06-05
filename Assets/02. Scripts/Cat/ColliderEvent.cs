using UnityEngine;

public class ColliderEvent : MonoBehaviour
{
    public GameObject fadeUI;
    private void OnCollisionEnter2D(Collision2D other)
    {
        // 충돌한 오브젝트가 "Ground" 태그를 가진 경우
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit!");
            CatController.catHealth -= 10f;
        }
    }
}
