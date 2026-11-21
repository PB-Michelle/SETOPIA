using UnityEngine;

public class PurificationTrigger : MonoBehaviour
{
    public GameObject pollutedEnvironment;
    public GameObject restoredEnvironment;

    public SubtitleController subtitleController;

    public string purificationMessage =
        "The environment is recovering";

    public bool purifierCollected = false;

    private bool activated = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // No permitir activación antes de iniciar la partida.
        if (!PauseMenuController.GameStarted)
            return;

        // Evitar múltiples activaciones.
        if (activated)
            return;

        // Solo el jugador puede activar el trigger.
        if (!other.CompareTag("Player"))
            return;

        // El purificador debe haberse recogido primero.
        if (!purifierCollected)
        {
            Debug.Log("You must collect the purifier first.");
            return;
        }

        activated = true;

        // Mostrar mensaje.
        if (subtitleController != null)
        {
            subtitleController.ShowSubtitle(
                purificationMessage);
        }

        // Ocultar entorno contaminado.
        if (pollutedEnvironment != null)
        {
            pollutedEnvironment.SetActive(false);
        }

        // Mostrar entorno restaurado.
        if (restoredEnvironment != null)
        {
            restoredEnvironment.SetActive(true);

            // Reproducir audio del entorno restaurado.
            AudioSource audioSource =
                restoredEnvironment.GetComponentInChildren<AudioSource>();

            if (audioSource != null)
            {
                audioSource.Play();
            }
            else
            {
                Debug.Log("No AudioSource found in restored environment.");
            }
        }
    }
}