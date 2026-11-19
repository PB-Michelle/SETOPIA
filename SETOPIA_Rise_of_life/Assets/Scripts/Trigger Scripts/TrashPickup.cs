
using UnityEngine;
using TMPro;

public class TrashPickup : MonoBehaviour
{
    public TMP_Text objectiveText;

    // Shared counter for all trash bags.
    private static int trashCount = 0;
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void ResetCounter()
    {
        trashCount = 0;
    }

    private int purifierCount = 1;

    private bool collected = false;

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

            UpdateCounter();

            Debug.Log("WASTE COLLECTED");
            Debug.Log("Trash count: " + trashCount);

            gameObject.SetActive(false);
        }
    }

    private void UpdateCounter()
    {
        if (objectiveText != null)
        {
            objectiveText.text = "x" + trashCount + "   x" + purifierCount;
        }
    }
}
