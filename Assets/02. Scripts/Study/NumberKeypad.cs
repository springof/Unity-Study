using TMPro;
using UnityEngine;

public class NumberKeypad : MonoBehaviour
{
    public string password;
    public string keypadNumber;
    public TextMeshProUGUI showPWUI;
    public Animator doorAnim;
    public GameObject doorLock;

    public void OnInputNumber(string numString)
    {
        if (showPWUI.text.Length < 6)
        {
            keypadNumber += numString;
            showPWUI.text = keypadNumber;
        }
    }

    public void OnCheckNumber()
    {
        if (keypadNumber == password)
        {
            Debug.Log("비밀번호가 일치합니다.");
            doorAnim.SetTrigger("Open");
            doorLock.SetActive(false);
            keypadNumber = "";
        }
        else
        {
            Debug.Log("비밀번호가 일치하지 않습니다.");
            keypadNumber = "";
            showPWUI.text = keypadNumber;
            doorLock.SetActive(false);
        }
    }
}
