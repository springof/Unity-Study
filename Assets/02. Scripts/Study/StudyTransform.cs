using UnityEngine;

public class StudyTransform : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 50f;

    void Update()
    {
        //transform.position += transform.forward * moveSpeed * Time.deltaTime; //월드 방향

        //transform.localPosition += Vector3.forward * moveSpeed * Time.deltaTime; //로컬 방향

        //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime); //로컬 방향

        //float angle = transform.rotation.eulerAngles.y + rotateSpeed * Time.deltaTime;
        //float localX = transform.localRotation.eulerAngles.x;
        //float localY = transform.localRotation.eulerAngles.y;
        //float localZ = transform.localRotation.eulerAngles.z;

        //transform.rotation = Quaternion.Euler(localX, angle, localZ); //월드방향 회전

        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime); //로컬방향 회전
        //transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World); //로컬방향 회전

        transform.RotateAround(Vector3.zero, Vector3.up, rotateSpeed * Time.deltaTime); //특정 위치의 주변을 회전
        //transform.RotateAround(new Vector3(0f, 0f, 0f), new Vector3(0f, 1f, 0fJ), rotateSpeed * Time.deltaTime); //특정 위치의 주변을 회전

        transform.LookAt(Vector3.zero); //특정 위치를 바라보기
    }
}
