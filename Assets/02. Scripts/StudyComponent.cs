using UnityEngine;

public class StudyComponent : MonoBehaviour
{
    public GameObject obj;

    public string changeName; //유니티에서 설정할 문자열 변수

    void Start()
    {
        obj.name = changeName;
    }
}
