using UnityEngine;

public class DestroyEvent : MonoBehaviour
{
    public float destroyTime = 3f;
    void Start()
    {
        Destroy(this.gameObject, destroyTime); //3초 후 자기자신 파괴
    }

    void OnDestroy()
    {
        Debug.Log($"{this.gameObject.name}가 파괴되었습니다.");
    }
}
