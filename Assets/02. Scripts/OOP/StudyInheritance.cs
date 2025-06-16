using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class StudyInheritance : MonoBehaviour
{
    public List<Person> persons = new List<Person>();

    private void Start()
    {
        for (int i = 0; i < 10; i++) // 10명씩 생성
        {
            Student student = new Student();
            persons.Add(student);
            Soldier soldier = new Soldier();
            persons.Add(soldier);
        }
    }

    public void AllMove() //모든 객체마다 이동 기능 실행
    {
        foreach (var person in persons)
            person.Walk();
    }
}
