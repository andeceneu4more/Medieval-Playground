using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public object Hashtable { get; private set; }

    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void LoadGame()
    {
        PlayersData data = SaveLoad.LoadSystem();
        if (data != null)
        {
            var arguments:Hashtable = {"data" : data};
            SceneManager.LoadScene(data.sceneIndex, arguments);
        }
    }
}
