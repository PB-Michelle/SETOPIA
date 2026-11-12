using UnityEngine;
using System.Collections;

// Handles tutorial trigger events when the player enters a specific area.
public class TutorialTrigger : MonoBehaviour
{
    public UIButtonHighlight[] buttonHighlights;

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
            Debug.Log("TRIGGER ACTIVADO");

            // Displays the tutorial message using the subtitle system.
            if (subtitleController != null)
            {
                subtitleController.ShowSubtitle(tutorialMessage);
            }

            // Starts the highlight animation on the assigned button.
            if (buttonHighlights != null && buttonHighlights.Length > 0)
            {
                foreach (UIButtonHighlight button in buttonHighlights)
                {
                    if (button != null)
                    {
                        button.StartHighlight();
                    }
                }

                // Stops the highlight after a few seconds.
                StartCoroutine(StopHighlight());
            }
        }
    }

    private IEnumerator StopHighlight()
    {
        // Wait for 2 seconds before stopping the highlight effect.
        yield return new WaitForSeconds(4f);

        if (buttonHighlights != null && buttonHighlights.Length > 0)
        {
            // Stop the button's pulsing effect.
            foreach (UIButtonHighlight button in buttonHighlights)
            {
                if (button != null)
                {
                    button.StopHighlight();
                }
            }
        }

        // Disables the trigger permanently after activation.
        gameObject.SetActive(false);
    }
}