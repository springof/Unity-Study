using UnityEngine;

public class StudyGeneric : MonoBehaviour
{
    //void Start()
    //{
    //    Factory<Monster> factory = new Factory<Monster>();
    //}

    public void CreateAccount(string name)
    {
        int dummyAge = 20;
        CreateAccount(name, dummyAge);
    }

    public void CreateAccount(string name, int age)
    {
        string dummyPhone = "010-1234-5678";
        CreateAccount(name, age, dummyPhone);
    }
    public void CreateAccount(string name, int age, string phone)
    {
        string dummyMail = "email@unity.com";
        CreateAccount(name, age, phone, dummyMail);
    }
    public void CreateAccount(string name, int age, string phone, string mail)
    {
        Debug.Log($"이름: {name}, 나이: {age}, 전화번호: {phone}, 이메일: {mail}");
    }
}
