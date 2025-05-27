using UnityEngine;

public class StudyMaterial : MonoBehaviour
{
    public Material mat; // 유니티 에디터에서 할당할 Material

    public string hexCode; // 유니티 에디터에서 할당할 Hex 코드

    void Start()
    {
        //this.GetComponent<Material>() = mat; // 잘못된 코드: Material 컴포넌트는 직접 할당할 수 없습니다.

        //this.GetComponent<MeshRenderer>().material = mat;

        //this.GetComponent<MeshRenderer>().sharedMaterial = mat;

        //this.GetComponent<MeshRenderer>().material.color = Color.green;

        //this.GetComponent<MeshRenderer>().sharedMaterial.color = Color.white;

        //this.GetComponent<MeshRenderer>().material.color = new Color(200f/255f, 255f/255f, 220f/255f, 1);

        mat = this.GetComponent<MeshRenderer>().material;
        Color outputColor;

        if (ColorUtility.TryParseHtmlString(hexCode, out outputColor))
        {
            mat.color = outputColor;
        }
    }


}
