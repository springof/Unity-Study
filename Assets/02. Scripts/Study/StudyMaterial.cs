using UnityEngine;

public class StudyMaterial : MonoBehaviour
{
    public Material mat; // ����Ƽ �����Ϳ��� �Ҵ��� Material

    public string hexCode; // ����Ƽ �����Ϳ��� �Ҵ��� Hex �ڵ�

    void Start()
    {
        //this.GetComponent<Material>() = mat; // �߸��� �ڵ�: Material ������Ʈ�� ���� �Ҵ��� �� �����ϴ�.

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
