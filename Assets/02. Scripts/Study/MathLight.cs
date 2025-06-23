using System;
using UnityEngine;

public class MathLight : MonoBehaviour
{
    private Light lightPoint;
    private float theta;
    [SerializeField] private float power;
    [SerializeField] private float speed;

    private void Start()
    {
        lightPoint = GetComponent<Light>();
    }

    private void Update()
    {
        theta += Time.deltaTime;

        lightPoint.intensity = Mathf.Sin(theta);
    }
}
