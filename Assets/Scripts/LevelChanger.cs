using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private DragonDoorControler DragonDoorControler;
    [SerializeField] private KnightDoorControler KnightDoorControler;

    private int levelToLoad;

    /// <summary>
    /// Players pass to the next level when both doors are opened
    /// </summary>
    void Update()
    {
        if (DragonDoorControler.isTouchedCheck() && KnightDoorControler.isTouchedCheck())
        {
            FadeToLevel((SceneManager.GetActiveScene().buildIndex + 1) % 5);
        }
    }

    /// <summary>
    /// Activate the animation for entering the next level
    /// </summary>
    public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    /// <summary>
    /// Called after the fade out animation
    /// </summary>
    public void OnFadeComplete ()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
