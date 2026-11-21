
using UnityEngine;

public class PuddleDamage : MonoBehaviour
{
    [Header("Damage Settings")]
    public float damageAmount = 20f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth =
                other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);

                Debug.Log("Player touched contaminated puddle. Damage: "
                    + damageAmount);
            }
        }
    }
}
