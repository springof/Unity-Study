using UnityEngine;

public class StudyComponent : MonoBehaviour
{
    private GameObject obj;

    public string changeName; //����Ƽ���� ������ ���ڿ� ����

    void Start()
    {
        obj = GameObject.Find("Main Camera");

        obj.name = changeName;
    }
}
