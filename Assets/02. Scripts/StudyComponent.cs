using UnityEngine;

public class StudyComponent : MonoBehaviour
{
    public GameObject obj;
    public Mesh msh;
    public Material mat;

    public Transform objTf;
    //public string changeName; //유니티에서 설정할 문자열 변수
    void Start()
    {
        obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //obj = GameObject.Find("Main Camera");
        obj = GameObject.FindGameObjectWithTag("Player");
        objTf = GameObject.FindGameObjectWithTag("Player").transform;

        //obj.GetComponent<MeshRenderer>().enabled = false;
        //obj.name = changeName;
        Debug.Log($"<color=#FFFFFF>name: {obj.name}</color>");
        Debug.Log($"tag: {obj.tag}");
        Debug.Log($"layer: {obj.layer}");
        Debug.Log($"position: {obj.transform.position}");
        Debug.Log($"rotation: {obj.transform.rotation}");
        Debug.Log($"scale: {obj.transform.localScale}");

        Debug.Log($"Meshfilter: {obj.GetComponent<MeshFilter>().mesh}");
        Debug.Log($"Material: {obj.GetComponent<MeshRenderer>().material}");
    }

    public void CreateCube()
    {
        obj = new GameObject("Cube");

        obj.AddComponent<MeshFilter>();
        obj.AddComponent<MeshFilter>().mesh = msh;

        obj.AddComponent<MeshRenderer>();
        obj.GetComponent<MeshRenderer>().material = mat;

        obj.AddComponent<BoxCollider>();
    }
}
