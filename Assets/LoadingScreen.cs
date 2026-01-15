using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public GameObject LoadingScreenUI;
    public Slider progressBar;
    public TMP_Text loadingText;
    public float stepDuration = 1.5f;

    public void ShowLoadingScreen()
    {
        StartCoroutine(LoadStuff());
    }

    private IEnumerator LoadStuff()
    {
        LoadingScreenUI.SetActive(true);
        progressBar.value = 0f;

        // Step 1
        yield return StartCoroutine(LoadingStep(
            "Calling A.I. API ...",
            0f,
            0.33f
        ));

        // Step 2
        yield return StartCoroutine(LoadingStep(
            "Generating music ...",
            0.33f,
            0.66f
        ));

        // Step 3
        yield return StartCoroutine(LoadingStep(
            "Loading data ...",
            0.66f,
            1f
        ));

        progressBar.value = 1f;
        yield return new WaitForSeconds(0.2f);

        LoadingScreenUI.SetActive(false);
    }

    private IEnumerator LoadingStep(string text, float startValue, float endValue)
    {
        loadingText.text = text;

        float elapsed = 0f;
        progressBar.value = startValue;

        float duration = stepDuration + Random.Range(-1f, 1f);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            progressBar.value = Mathf.Lerp(startValue, endValue, elapsed / stepDuration);
            yield return null;
        }

        progressBar.value = endValue;
    }
}
