using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    [Header("Menus")]
    public GameObject pauseMenu;
    public GameObject mainMenu;
    public GameObject settingsMenu;

    [Header("Audio")]
    public AudioClip openMenuClip;
    public AudioClip closeMenuClip;

    public AudioSource menuMusic;
    public AudioSource playButtonSound;
    public AudioSource pollutedEnvironmentAudio;

    private AudioSource audioSource;

    public static bool GameStarted = false;

    private bool openedFromPauseMenu = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        GameStarted = false;
        Time.timeScale = 0f;

        if (pollutedEnvironmentAudio != null)
        {
            pollutedEnvironmentAudio.Stop();
        }

        if (mainMenu != null)
        {
            mainMenu.SetActive(true);
        }

        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }

        if (settingsMenu != null)
        {
            settingsMenu.SetActive(false);
        }

        if (menuMusic != null && !menuMusic.isPlaying)
        {
            menuMusic.Play();
        }
    }   

    private void PlayOpenSound()
    {
        if (audioSource != null && openMenuClip != null)
        {
            audioSource.PlayOneShot(openMenuClip);
        }
    }

    private void PlayCloseSound()
    {
        if (audioSource != null && closeMenuClip != null)
        {
            audioSource.PlayOneShot(closeMenuClip);
        }
    }

    // ==========================
    // START GAME
    // ==========================

    public void StartGame()
    {
        GameStarted = true;

        Time.timeScale = 1f;

        if (playButtonSound != null)
        {
            playButtonSound.Play();
        }

        if (menuMusic != null)
        {
            menuMusic.Stop();
        }

        if (pollutedEnvironmentAudio != null)
        {
            pollutedEnvironmentAudio.Play();
        }

        if (mainMenu != null)
        {
            mainMenu.SetActive(false);
        }
    }

    // ==========================
    // MAIN MENU
    // ==========================

    public void OpenMainMenu()
    {
        PlayOpenSound();

        mainMenu.SetActive(true);
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }

    public void CloseMainMenu()
    {
        // El menú principal inicial no puede cerrarse
        // mientras no haya comenzado la partida.
        if (!GameStarted)
            return;

        PlayCloseSound();

        mainMenu.SetActive(false);
    }

    // ==========================
    // SETTINGS
    // ==========================

    public void OpenSettingsFromMain()
    {
        PlayOpenSound();

        openedFromPauseMenu = false;

        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void OpenSettingsFromPause()
    {
        PlayOpenSound();

        openedFromPauseMenu = true;

        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void CloseSettingsMenu()
    {
        PlayCloseSound();

        settingsMenu.SetActive(false);

        if (openedFromPauseMenu)
        {
            pauseMenu.SetActive(true);
        }
        else
        {
            mainMenu.SetActive(true);
        }
    }

    // ==========================
    // PAUSE MENU
    // ==========================

    public void OpenPauseMenu()
    {
        if (!GameStarted)
            return;

        PlayOpenSound();

        pauseMenu.SetActive(true);
    }

    public void ClosePauseMenu()
    {
        PlayCloseSound();

        pauseMenu.SetActive(false);
    }
}