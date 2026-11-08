using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Controls the display and automatic hiding of tutorial subtitles.
public class SubtitleController : MonoBehaviour
{
    // Reference to the TextMeshPro component used to display subtitle messages.
    public TMP_Text subtitleText;

    // Reference to the UI Image used as the subtitle background.
    public Image subtitleBackground;

    // Displays a subtitle message and starts the automatic hiding process.
    public void ShowSubtitle(string message)
    {
        // Stops any previously running coroutines to prevent overlapping subtitles.
        StopAllCoroutines();

        // Updates the subtitle text with the received message.
        subtitleText.text = message;

        // Gets the current background color.
        Color bg = subtitleBackground.color;

        // Sets the background opacity to 70%.
        bg.a = 0.7f;

        // Applies the updated color to the subtitle background.
        subtitleBackground.color = bg;

        // Starts the coroutine responsible for hiding the subtitle.
        StartCoroutine(HideSubtitle());
    }

    // Hides the subtitle after a specified delay.
    IEnumerator HideSubtitle()
    {
        // Waits for two seconds before hiding the subtitle.
        yield return new WaitForSeconds(3f);

        // Clears the subtitle text.
        subtitleText.text = "";

        // Gets the current background color.
        Color bg = subtitleBackground.color;

        // Sets the background opacity to 0%, making it fully transparent.
        bg.a = 0f;

        // Applies the updated color to the subtitle background.
        subtitleBackground.color = bg;
    }
}
