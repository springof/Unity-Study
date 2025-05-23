using UnityEngine;

public class StudyArray_List : MonoBehaviour
{
    public int[] array = new int[5];

    void Start()
    {
        for (int i = 0; i <= array.Length; i++)
        {
            array[i] = i * 10;
            Debug.Log($"array[{i}] = {array[i]}");
        }
    }
}
