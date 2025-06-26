using System.Collections;
using TMPro;
using UnityEngine;

public class TypingText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textUI;
    private string currText;
    [SerializeField] private float typingSpeed = 0.05f;

    private void Awake()
    {
        currText = textUI.text;
    }

    private void OnEnable()
    {
        textUI.text = string.Empty;

        StartCoroutine(TypingRoutine());
    }

    IEnumerator TypingRoutine()
    {
        int textCount = currText.Length;
        for (int  i = 0;  i < textCount;  i++)
        {
            textUI.text += currText[i];
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
