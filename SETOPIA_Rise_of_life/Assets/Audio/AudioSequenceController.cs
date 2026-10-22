using System.Collections;
using UnityEngine;

public class AudioSequenceController : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource pollutedAmbience;
    public AudioSource purifierActivation;
    public AudioSource purifierRunning;
    public AudioSource recoveryFeedback;
    public AudioSource restoredAmbience;

    [Header("Transition Settings")]
    public float activationDelay = 90f;
    public float runningDelay = 150f;
    public float recoveryDelay = 300f;
    public float fadeDuration = 9f;

    void Start()
    {
        StartCoroutine(PlaySequence());
    }

    IEnumerator PlaySequence()
    {
        yield return new WaitForSeconds(activationDelay);

        purifierActivation.Play();

        yield return new WaitForSeconds(runningDelay - activationDelay);

        purifierRunning.Play();

        yield return new WaitForSeconds(recoveryDelay - runningDelay);

        recoveryFeedback.Play();

        restoredAmbience.Play();

        StartCoroutine(FadeOut(pollutedAmbience, fadeDuration));
        StartCoroutine(FadeIn(restoredAmbience, fadeDuration, 0.6f));
    }

    IEnumerator FadeOut(AudioSource source, float duration)
    {
        float startVolume = source.volume;

        while (source.volume > 0)
        {
            source.volume -= startVolume * Time.deltaTime / duration;
            yield return null;
        }

        source.Stop();
        source.volume = startVolume;
    }

    IEnumerator FadeIn(AudioSource source, float duration, float targetVolume)
    {
        source.volume = 0;

        while (source.volume < targetVolume)
        {
            source.volume += targetVolume * Time.deltaTime / duration;
            yield return null;
        }

        source.volume = targetVolume;
    }
}