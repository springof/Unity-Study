using UnityEngine;
using UnityEngine.UIElements;

public class StudyGameObject : MonoBehaviour
{
    public GameObject prefab;
    public GameObject destroyObj;
    public Vector3 Pos;
    public Quaternion Rot;

    void Start()
    {
        CreateCharacter();
        //Debug.Log("�����Ǿ����ϴ�.");
        //Destroy(destroyObj, 3f);
    }
    //void OnDestroy()
    //{
    //    Debug.Log("�ı��Ǿ����ϴ�.");
    //}

    public void CreateCharacter()
    {
        GameObject obj = Instantiate(prefab, Pos, Rot); //GameObject�� �����ϴ� ���
        obj.name = "����";
        Transform objTf = obj.transform;
        int count = objTf.childCount;

        Debug.Log($"ĳ������ �ڽ� ������Ʈ�� �� : {count}");
        Debug.Log($"ĳ������ ù��° �ڽ� ������Ʈ�� �̸� : {objTf.GetChild(0).name}");
        Debug.Log($"ĳ������ ������ �ڽ� ������Ʈ�� �̸� : {obj.transform.GetChild(count - 1).name}");
    }
}
