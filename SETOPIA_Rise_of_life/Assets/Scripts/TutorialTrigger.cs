using UnityEngine;

// Handles tutorial trigger events when the player enters a specific area.
public class TutorialTrigger : MonoBehaviour
{
    // Reference to the subtitle system.
    public SubtitleController subtitleController;

    // Stores the tutorial message to be displayed when the trigger is activated.
    public string tutorialMessage;

    // Tracks whether the trigger has already been activated.
    private bool activated = false;

    // Called when another 2D collider enters this trigger zone.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Prevents the trigger from being activated more than once.
        if (activated)
            return;

        // Checks if the object entering the trigger has the Player tag.
        if (other.CompareTag("Player"))
        {
            // Marks the trigger as activated.
            activated = true;

            // Displays the tutorial message using the subtitle system.
            subtitleController.ShowSubtitle(tutorialMessage);
        }
    }
}
