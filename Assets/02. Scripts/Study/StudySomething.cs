using UnityEngine;

public class StudySomething : MonoBehaviour
{
    public int currentLevel = 10;

    public int maxLevel = 20;

    private void Start()
    {
        string msg = currentLevel >= maxLevel ? "현재 만렙입니다." : "현재 레벨은 " + currentLevel + "입니다.";

        Debug.Log(msg);
    }
}
