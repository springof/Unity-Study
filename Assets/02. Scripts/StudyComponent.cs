using UnityEngine;

public class StudyComponent : MonoBehaviour
{
    public GameObject obj;

    public string changeName; //����Ƽ���� ������ ���ڿ� ����

    void Start()
    {
        obj.name = changeName;
    }
}
