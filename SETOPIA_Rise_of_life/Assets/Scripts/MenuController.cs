using UnityEngine;
public class PauseMenuController : MonoBehaviour
{
    [Header("Menus")]
    public GameObject pauseMenu;
    public GameObject mainMenu;
    public GameObject settingsMenu;

    private bool openedFromPauseMenu = false;

    // MAIN MENU
    public void OpenMainMenu()
    {
        mainMenu.SetActive(true);
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }

    public void CloseMainMenu()
    {
        mainMenu.SetActive(false);
    }

    // SETTINGS

    public void OpenSettingsFromMain()
    {
        openedFromPauseMenu = false;
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    public void OpenSettingsFromPause()
    {
        openedFromPauseMenu = true;
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    public void CloseSettingsMenu()
    {
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

    // PAUSE MENU
    public void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
    }

    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
    }
}