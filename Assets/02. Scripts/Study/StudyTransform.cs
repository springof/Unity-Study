using UnityEngine;

public class StudyTransform : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 50f;

    void Update()
    {
        //transform.position += transform.forward * moveSpeed * Time.deltaTime; //���� ����

        //transform.localPosition += Vector3.forward * moveSpeed * Time.deltaTime; //���� ����

        //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime); //���� ����

        //float angle = transform.rotation.eulerAngles.y + rotateSpeed * Time.deltaTime;
        //float localX = transform.localRotation.eulerAngles.x;
        //float localY = transform.localRotation.eulerAngles.y;
        //float localZ = transform.localRotation.eulerAngles.z;

        //transform.rotation = Quaternion.Euler(localX, angle, localZ); //������� ȸ��

        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime); //���ù��� ȸ��
        //transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World); //���ù��� ȸ��

        transform.RotateAround(Vector3.zero, Vector3.up, rotateSpeed * Time.deltaTime); //Ư�� ��ġ�� �ֺ��� ȸ��
        //transform.RotateAround(new Vector3(0f, 0f, 0f), new Vector3(0f, 1f, 0fJ), rotateSpeed * Time.deltaTime); //Ư�� ��ġ�� �ֺ��� ȸ��

        transform.LookAt(Vector3.zero); //Ư�� ��ġ�� �ٶ󺸱�
    }
}
