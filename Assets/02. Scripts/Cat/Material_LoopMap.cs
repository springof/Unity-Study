using UnityEngine;

public class Material_LoopMap : MonoBehaviour
{
    private MeshRenderer renderers;
    public float offsetSpeed = 0.0001f;

    void Start()
    {
        renderers = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        Vector2 offset = Vector2.right * offsetSpeed * Time.deltaTime;

        renderers.material.SetTextureOffset("_MainTex", renderers.material.mainTextureOffset + offset);
    }
}
