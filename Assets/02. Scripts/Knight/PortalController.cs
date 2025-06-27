using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PortalController : MonoBehaviour
{
    public FadeRoutine fade;
    public GameObject portalEffect;
    public GameObject loadingImage;

    public Image progressBar;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PortalRoutine());
        }
    }

    IEnumerator PortalRoutine()
    {
        portalEffect.SetActive(true);

        yield return StartCoroutine(fade.Fade(3f, Color.white, true)); // 페이드 온

        loadingImage.SetActive(true); // 로딩창 활성화

        yield return StartCoroutine(fade.Fade(3f, Color.white, false)); // 페이드 오프

        while (progressBar.fillAmount < 1f)
        {
            progressBar.fillAmount += Time.deltaTime * 0.3f; // 3초 동안 프로그레스 바 채우기

            yield return null;
        }

        // 씬 변경
        SceneManager.LoadScene(1);

        // 페이드 오프
    }
}
