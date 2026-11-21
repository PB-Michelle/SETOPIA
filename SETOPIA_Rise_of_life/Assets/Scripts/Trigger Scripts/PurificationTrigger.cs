
using UnityEngine;

public class PurificationTrigger : MonoBehaviour
{
    public GameObject pollutedEnvironment;
    public GameObject restoredEnvironment;
    public SubtitleController subtitleController;
    public string purificationMessage = "The environment is recovering";

    public static bool purifierCollected = false;

    private bool activated = false;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void ResetPurifier()
    {
        purifierCollected = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!PauseMenuController.GameStarted)
            return;

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

        // Display the purification message.
        if (subtitleController != null)
        {
            subtitleController.ShowSubtitle(
                purificationMessage);
        }

        // Hide the polluted environment.
        if (pollutedEnvironment != null)
        {
            pollutedEnvironment.SetActive(false);
        }

        // Show the restored environment.
        if (restoredEnvironment != null)
        {
            restoredEnvironment.SetActive(true);

            // Play the audio source inside the restored environment.
            AudioSource audioSource = restoredEnvironment.GetComponentInChildren<AudioSource>();

                if (audioSource != null)
                {
                    Debug.Log("Audio encontrado: " + audioSource.name);
                    audioSource.Play();
                }
                else
                {
                    Debug.Log("No se encontró AudioSource");
                }
            }
    }
}
