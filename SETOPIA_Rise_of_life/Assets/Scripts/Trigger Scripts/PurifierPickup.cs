
using UnityEngine;

public class PurifierPickup : MonoBehaviour
{
    private bool collected = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (collected)
            return;

        if (other.CompareTag("Player"))
        {
            collected = true;

            PurificationTrigger.purifierCollected = true;

            Debug.Log("PURIFIER COLLECTED");

            TrashPickup[] pickups =
                FindObjectsByType<TrashPickup>(
                    FindObjectsSortMode.None);

            foreach (TrashPickup pickup in pickups)
            {
                pickup.RefreshCounter();
            }

            gameObject.SetActive(false);
        }
    }
}
