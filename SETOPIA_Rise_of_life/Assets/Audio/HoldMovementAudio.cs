using UnityEngine;
using UnityEngine.EventSystems;

public class HoldMovementAudio : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public AudioSource audioSource;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        audioSource.Pause();
    }
}