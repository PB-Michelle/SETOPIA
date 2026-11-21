
using UnityEngine;

public class PuddleAnimation : MonoBehaviour
{
    [Header("Water Movement")]
    public float waveSpeed = 1.5f;
    public float waveAmount = 0.025f;

    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        float wave = Mathf.Sin(Time.time * waveSpeed) * waveAmount;

        transform.localScale = new Vector3(
            originalScale.x,
            originalScale.y + wave,
            originalScale.z
        );
    }
}
