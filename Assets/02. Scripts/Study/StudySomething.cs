using UnityEngine;

public class StudySomething : MonoBehaviour
{
    public int currentLevel = 10;

    public int maxLevel = 20;

    private void Start()
    {
        string msg = currentLevel >= maxLevel ? "���� �����Դϴ�." : "���� ������ " + currentLevel + "�Դϴ�.";

        Debug.Log(msg);
    }
}
