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
    private Animator mainMenuAnimator;

    public static bool GameStarted = false;
    private bool openedFromPauseMenu = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        mainMenuAnimator = mainMenu.GetComponent<Animator>();

        GameStarted = false;
        Time.timeScale = 0f;

        if (pollutedEnvironmentAudio != null)
        {
            pollutedEnvironmentAudio.Stop();
        }

        if (mainMenuAnimator != null)
        {
            mainMenuAnimator.enabled = false;
        }

        // Mostrar menú principal al inicio
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

        // Reproducir música del menú inicial
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

    // =====================================
    // PLAY GAME
    // =====================================

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

        mainMenu.SetActive(false);
    }

    // =====================================
    // MAIN MENU
    // =====================================

    public void OpenMainMenu()
    {
        PlayOpenSound();

        mainMenu.SetActive(true);
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);

        if (mainMenuAnimator != null)
        {
            mainMenuAnimator.enabled = true;
        }
    }

    public void CloseMainMenu()
    {
        // El menú principal no puede cerrarse
        // antes de pulsar Play
        if (!GameStarted)
            return;

        PlayCloseSound();

        mainMenu.SetActive(false);
    }

    // =====================================
    // SETTINGS
    // =====================================

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

    // =====================================
    // PAUSE MENU
    // =====================================

    public void OpenPauseMenu()
    {
        // No permitir pausa antes de iniciar partida
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