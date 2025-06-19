using System;
using UnityEngine;

public class MathLight : MonoBehaviour
{
    private Light light;
    private float theta;
    [SerializeField] private float power;
    [SerializeField] private float speed;

    private void Start()
    {
        light = GetComponent<Light>();
    }

    private void Update()
    {
        theta += Time.deltaTime;

        light.intensity = Mathf.Sin(theta);
    }
}
