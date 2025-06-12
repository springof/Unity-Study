using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class LottoGenerator : MonoBehaviour
{
    //public int[] intArray = new int[10];
    public List<int> intList = new List<int>();

    public int shakeCount = 1000;

    private void Awake()
    {
        for (int i = 1; i < 46; i++)
        {
            intList.Add(i);
        }
    }

    IEnumerator Start()
    {
        for (int i = 0; i < shakeCount; i++)
        {
            int ranInt1 = Random.Range(0, intList.Count);
            int ranInt2 = Random.Range(0, intList.Count);

            var temp = intList[ranInt1];
            intList[ranInt1] = intList[ranInt2];
            intList[ranInt2] = temp;

            yield return new WaitForSeconds(0.001f); // 0.1초 대기
        }
        List<int> selectedNumbers = new List<int>();
        for (int i = 0; i < 6; i++)
        {
            selectedNumbers.Add(intList[i]);
        }
        selectedNumbers.Sort();
        string result = $"Lotto Numbers:{selectedNumbers[0]}, {selectedNumbers[1]}, {selectedNumbers[2]}, {selectedNumbers[3]}, {selectedNumbers[4]}, {selectedNumbers[5]}";

        Debug.Log(result);
    }
}
