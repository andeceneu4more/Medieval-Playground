using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenuUI;

    public GameObject pauseButtonUI;

    public DragonControler dragon;
    public KnightControler knight;
    public TimerControler timer;

    /// <summary>
    /// Set pause menu invisible, pause button visible and unfreeze time
    /// </summary>
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        pauseButtonUI.SetActive(true);
        Time.timeScale = 1f;
    }
    
    /// <summary>
    /// Set pause menu visible, pause button invisible and freeze time
    /// </summary>
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        pauseButtonUI.SetActive(false);
        Time.timeScale = 0f;
    }

    /// <summary>
    /// Called when the Quit Button is pressed and end session
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Called when the Menu Button is pressed and Menu Scene is loaded
    /// </summary>
    public void LoadMenu()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("Menu");
    }

    /// <summary>
    /// Called when the Retry Button is pressed and restart the current scene
    /// </summary>
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Called when the Save Button is pressed and save the configurations
    /// </summary>
    public void Save()
    {
        SaveLoad.SaveSystem(knight, dragon, timer);
    }
}
