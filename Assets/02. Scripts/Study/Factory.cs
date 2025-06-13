using UnityEngine;

public class Factory<T> : MonoBehaviour
{
    public T prefab;

    public Factory()
    {
        Debug.Log($"현재 Factory의 타입은 {typeof(T)}입니다.");
    }
}
