
using UnityEngine;

public class PurificationTrigger : MonoBehaviour
{
    public GameObject pollutedEnvironment;
    public GameObject restoredEnvironment;
    public SubtitleController subtitleController;

    public string purificationMessage =
        "The environment is recovering";

    public static bool purifierCollected = false;

    private bool activated = false;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void ResetPurifier()
    {
        purifierCollected = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (activated)
            return;

        if (!other.CompareTag("Player"))
            return;

        // The player must collect the purifier first.
        if (!purifierCollected)
        {
            Debug.Log("You must collect the purifier first.");
            return;
        }

        activated = true;

        if (subtitleController != null)
        {
            subtitleController.ShowSubtitle(
                purificationMessage);
        }

        if (pollutedEnvironment != null)
            pollutedEnvironment.SetActive(false);

        if (restoredEnvironment != null)
            restoredEnvironment.SetActive(true);
    }
}
