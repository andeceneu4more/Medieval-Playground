using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Called when the Play Button is pressed and load the first map of the game
    /// </summary>
    public void PlayGame ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Called when the Quit Button is pressed and end session
    /// </summary>
    public void QuitGame ()
    {
        Application.Quit();
    }

    /// <summary>
    /// Called when the Load Button is pressed and load the saved map and configurations
    /// </summary>
    public void LoadGame()
    {
        Time.timeScale = 1f;
        PlayersData data = SaveLoad.LoadSystem();
        if (data != null)
        {
            // Get loaded scene and activate the configure load
            SaveLoad.loading = true;
            SceneManager.LoadScene(data.sceneIndex);
        }
    }
}
