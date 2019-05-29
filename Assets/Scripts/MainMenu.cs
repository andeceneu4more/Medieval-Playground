﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void LoadGame()
    {
        Time.timeScale = 1f;
        PlayersData data = SaveLoad.LoadSystem();
        if (data != null)
        {
            SaveLoad.loading = true;
            SceneManager.LoadScene(data.sceneIndex);
        }
    }
}
