using UnityEngine;

public class StudyPolygon : MonoBehaviour
{

    void Start()
    {
        Mesh mesh = new Mesh();

        Vector3[] vetrices = new Vector3[]
        {
            new Vector3(0f, 0f, 0f), //0
            new Vector3(1f, 0f, 0f), //1
            new Vector3(0f, 1f, 0f), //2
            new Vector3(1f, 1f, 0f), //3
        };

        int[] triangles = new int[]
        {
            0, 2, 1,
            2, 3, 1
        };

        Vector2[] uv = new Vector2[]
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1)
        };
        //Mesh에 위에서 만든 점, 삼각형 순서, uv 데이터를 적용
        mesh.vertices = vetrices;
        mesh.triangles = triangles;
        mesh.uv = uv;
        // MeshFilter에 mesh를 적용
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;
        // MeshRenderer에 머티리얼을 적용
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = new Material(Shader.Find("Sprites/Default"));
    }
}
