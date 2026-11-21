using UnityEngine;
using TMPro;

public class TrashPickup : MonoBehaviour
{
    public TMP_Text objectiveText;

    [Header("Pickup Sound")]
    public AudioClip pickupSound;
    [Range(0f, 1f)]
    public float soundVolume = 1f;

    private static int trashCount = 0;
    private bool collected = false;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void ResetCounter()
    {
        trashCount = 0;
    }

    private void Start()
    {
        UpdateCounter();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (collected)
            return;

        if (other.CompareTag("Player"))
        {
            collected = true;
            trashCount++;

            if (pickupSound != null)
            {
                AudioSource.PlayClipAtPoint(
                    pickupSound,
                    transform.position,
                    soundVolume
                );
            }

            UpdateCounter();

            Debug.Log("WASTE COLLECTED");
            Debug.Log("Trash count: " + trashCount);

            gameObject.SetActive(false);
        }
    }

    public void RefreshCounter()
    {
        UpdateCounter();
    }

    private void UpdateCounter()
    {
        if (objectiveText != null)
        {
            int purifierCount =
                PurificationTrigger.purifierCollected ? 1 : 0;

            objectiveText.text =
                "x" + trashCount + "   x" + purifierCount;
        }
    }
}