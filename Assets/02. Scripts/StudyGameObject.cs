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
        //Debug.Log("생성되었습니다.");
        //Destroy(destroyObj, 3f);
    }
    //void OnDestroy()
    //{
    //    Debug.Log("파괴되었습니다.");
    //}

    public void CreateCharacter()
    {
        GameObject obj = Instantiate(prefab, Pos, Rot); //GameObject를 생성하는 기능
        obj.name = "어몽어스";
        Transform objTf = obj.transform;
        int count = objTf.childCount;

        Debug.Log($"캐릭터의 자식 오브젝트의 수 : {count}");
        Debug.Log($"캐릭터의 첫번째 자식 오브젝트의 이름 : {objTf.GetChild(0).name}");
        Debug.Log($"캐릭터의 마지막 자식 오브젝트의 이름 : {obj.transform.GetChild(count - 1).name}");
    }
}
