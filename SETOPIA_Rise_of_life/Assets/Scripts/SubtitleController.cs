using TMPro;
using UnityEngine;

public class SubtitleController : MonoBehaviour
{
    public TMP_Text subtitleText;

    public void ShowSubtitle(string message)
    {
        subtitleText.text = message;
    }
}