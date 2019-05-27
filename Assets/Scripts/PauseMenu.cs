using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject pauseButtonUI;

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        pauseButtonUI.SetActive(true);
        //jocul reia de unde s-a pus pauza
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    
    public void Pause ()
    {
        pauseMenuUI.SetActive(true);
        pauseButtonUI.SetActive(false);
        //pun pauza jocului
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void LoadMenu ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Retry ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
