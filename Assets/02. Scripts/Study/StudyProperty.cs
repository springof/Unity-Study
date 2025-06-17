using UnityEngine;

public class StudyProperty : MonoBehaviour
{
    private int number1 = 10;
    public int Number1
    {
        get { return number1; }
        set { number1 = value; }
    }
    public int Number2 { get; set; } = 20;
    public int number2 = 20;
}
