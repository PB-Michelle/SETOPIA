using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SubtitleController : MonoBehaviour
{
    public TMP_Text subtitleText;
    public Image subtitleBackground;

    public void ShowSubtitle(string message)
    {
        StopAllCoroutines();

        subtitleText.text = message;

        Color bg = subtitleBackground.color;
        bg.a = 0.7f;
        subtitleBackground.color = bg;

        StartCoroutine(HideSubtitle());
    }

    IEnumerator HideSubtitle()
    {
        yield return new WaitForSeconds(2f);

        subtitleText.text = "";

        Color bg = subtitleBackground.color;
        bg.a = 0f;
        subtitleBackground.color = bg;
    }
}