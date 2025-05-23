using UnityEngine;

public class StudyLookAt : MonoBehaviour
{
    public Transform targetTf;
    public Transform turretHead;

    public GameObject bulletPrefab;
    public Transform firePos;

    public float timer;
    public float fireRate;

    void Start()
    {
        targetTf = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        turretHead.LookAt(targetTf);

        timer += Time.deltaTime;
        fireRate = 1f;
        if (timer >= fireRate)
        {
            timer = 0;
            Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        }
    }
}
