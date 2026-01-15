using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource sourceA;
    public AudioSource sourceB;

    [Header("New Audio Clips")]
    public AudioClip newClipA1;
    public AudioClip newClipB1;
    public AudioClip newClipA2;
    public AudioClip newClipB2;
    public AudioClip newClipA3;
    public AudioClip newClipB3;

    [Header("Fade Settings")]
    public float fadeDuration = 1f;
    public float targetVolume = 1f;

    public void OnButton1Clicked()
    {
        StartCoroutine(ChangeAudio1());
    }

    public void OnButton2Clicked()
    {
        StartCoroutine(ChangeAudio2()); 
    }

    public void OnButton3Clicked()
    {
        StartCoroutine(ChangeAudio3());
    }

    private IEnumerator ChangeAudio1()
    {
        yield return StartCoroutine(FadeOut(sourceA));
        yield return StartCoroutine(FadeOut(sourceB));

        sourceA.clip = newClipA1;
        sourceB.clip = newClipB1;

        sourceA.loop = true;
        sourceB.loop = true;

        sourceA.Play();
        sourceB.Play();

        StartCoroutine(FadeIn(sourceA));
        StartCoroutine(FadeIn(sourceB));
    }

    private IEnumerator ChangeAudio2()
    {
        yield return StartCoroutine(FadeOut(sourceA));
        yield return StartCoroutine(FadeOut(sourceB));

        sourceA.clip = newClipA2;
        sourceB.clip = newClipB2;

        sourceA.loop = true;
        sourceB.loop = true;

        sourceA.Play();
        sourceB.Play();

        StartCoroutine(FadeIn(sourceA));
        StartCoroutine(FadeIn(sourceB));
    }

    private IEnumerator ChangeAudio3()
    {
        yield return StartCoroutine(FadeOut(sourceA));
        yield return StartCoroutine(FadeOut(sourceB));

        sourceA.clip = newClipA3;
        sourceB.clip = newClipB3;

        sourceA.loop = true;
        sourceB.loop = true;

        sourceA.Play();
        sourceB.Play();

        StartCoroutine(FadeIn(sourceA));
        StartCoroutine(FadeIn(sourceB));
    }

    private IEnumerator FadeOut(AudioSource audioSource)
    {
        float startVolume = audioSource.volume;

        float time = 0f;
        while (time < fadeDuration)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0f, time / fadeDuration);
            time += Time.deltaTime;
            yield return null;
        }

        audioSource.volume = 0f;
        audioSource.Stop();
    }

    private IEnumerator FadeIn(AudioSource audioSource)
    {
        yield return new WaitForSeconds(8f);

        audioSource.volume = 0f;
        float time = 0f;

        while(time < fadeDuration)
        {
            audioSource.volume = Mathf.Lerp(0f, targetVolume, time / fadeDuration);
            time += Time.deltaTime;
            yield return null;
        }

        audioSource.volume = targetVolume;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
