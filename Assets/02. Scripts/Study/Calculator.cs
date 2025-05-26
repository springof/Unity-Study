using UnityEngine;

public class Calculator : MonoBehaviour
{
    public int number1, number2;

    void Start()
    {
        AddMethod();

        MinusMethod();

        Debug.Log($"AddMethod : {AddMethod()}, MinusMethod : {MinusMethod()}");
    }

    int AddMethod()
    {
        int result = number1 + number2;

        return result;
    }

    int MinusMethod()
    {
        int result = number1 - number2;

        return result;
    }
}