﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private DragonDoorControler DragonDoorControler;
    [SerializeField] private KnightDoorControler KnightDoorControler;

    private int levelToLoad;

    void Update()
    {
        if (DragonDoorControler.isTouchedCheck() && KnightDoorControler.isTouchedCheck())
        {
            FadeToLevel((SceneManager.GetActiveScene().buildIndex + 1) % 5);
        }
    }

    public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        Debug.Log(levelToLoad);
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete ()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
