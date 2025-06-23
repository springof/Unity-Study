using UnityEngine;

public class MathLerp : MonoBehaviour
{
    public Vector3 targetPos;
    public float smoothValue;

    private Vector3 startPos;
    private float timer, percent;
    public float LerpTime;

    private void Update()
    {
        timer += Time.deltaTime;
        //timer = Time.time;
        percent = timer / LerpTime;
        transform.position = Vector3.Lerp(startPos, targetPos, percent);
    }
}
