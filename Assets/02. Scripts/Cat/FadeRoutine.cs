using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeRoutine : MonoBehaviour
{
    public Image fadePanel; // 페이드 이미지

    public void OnFade(float fadeTime, Color color, bool isFadeStart)
    {
        StartCoroutine(Fade(fadeTime, color, isFadeStart));
    }

    IEnumerator Fade(float fadeTime, Color color, bool isFadeStart)
    {
        float timer = 0f;
        float percent = 0f;

        while (percent < 1f)
        {
            timer += Time.deltaTime;
            percent = timer / fadeTime;
            float value = isFadeStart ? percent : 1 - percent;

            fadePanel.color = new Color(color.r, color.g, color.b, percent);
            yield return null;
        }
    }
}
