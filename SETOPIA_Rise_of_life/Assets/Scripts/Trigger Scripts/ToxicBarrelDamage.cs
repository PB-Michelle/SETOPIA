
using UnityEngine;

public class ToxicBarrelDamage : MonoBehaviour
{
    public float damageAmount = 20f;

    private bool damageApplied = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        PlayerHealth health = other.GetComponentInParent<PlayerHealth>();

        if (health == null)
            return;

        if (damageApplied)
            return;

        health.TakeDamage(damageAmount);
        damageApplied = true;

        Debug.Log("TOXIC BARREL: 20 DAMAGE APPLIED");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponentInParent<PlayerHealth>() != null)
        {
            damageApplied = false;
        }
    }
}
