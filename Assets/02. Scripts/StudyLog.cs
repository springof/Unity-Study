using UnityEngine;

/// <summary>
/// ����Ƽ �����Ϳ� �ִ� Console View�� Log�� �׽�Ʈ�ϱ� ���� Ŭ����
/// </summary>

public class StudyLog : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start �Լ� ����");
        Debug.LogWarning("Start �Լ� ����");
        Debug.LogError("Start �Լ� ����");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}