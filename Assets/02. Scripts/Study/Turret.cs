using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform turretHead;

    private float theta;
    public float rotSpeed = 1f;
    public float rotRange = 60f;

    private bool isTarget;
    public Transform target;

    private void Update()
    {
        if (!isTarget) TurretIdle();
        else LookTarget();
    }

    void TurretIdle()
    {
        theta += Time.deltaTime * rotSpeed;

        float rotY = Mathf.Sin(theta) * rotRange;

        turretHead.localRotation = Quaternion.Euler(0f, rotY, 0f);
    }

    void LookTarget()
    {
        turretHead.LookAt(target);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            target = other.transform;
            isTarget = true;
        }
    }
}
