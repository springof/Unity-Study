using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Study_Casting : MonoBehaviour
{
    private void Start()
    {
        Monster m = new Monster();

        Orc o = m as Orc;

        if (o != null)
        {
            Debug.Log(o);
        }
        else
        {
            Debug.Log("형변 실패");
        }
    }
}