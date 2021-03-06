﻿using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayersData
{
    public float[] positionKnight;
    public float[] scaleKnight;
    public float[] positionDragon;
    public float[] scaleDragon;
    public float timer;
    public int sceneIndex;

    /// <summary>
    /// Constructor with 3 parameters
    /// </summary>
    /// <param name="knight"> stores the knight position and scale </param>
    /// <param name="dragon"> stores the dragon position and scale </param>
    /// <param name="timerControler"> stores the elapsed time </param>
    public PlayersData(KnightControler knight, DragonControler dragon, TimerControler timerControler)
    {
        positionKnight = new float[3];
        positionKnight[0] = knight.transform.localPosition.x;
        positionKnight[1] = knight.transform.localPosition.y;
        positionKnight[2] = knight.transform.localPosition.z;

        scaleKnight = new float[3];
        scaleKnight[0] = knight.transform.localScale.x;
        scaleKnight[1] = knight.transform.localScale.y;
        scaleKnight[2] = knight.transform.localScale.z;

        positionDragon = new float[3];
        positionDragon[0] = dragon.transform.localPosition.x;
        positionDragon[1] = dragon.transform.localPosition.y;
        positionDragon[2] = dragon.transform.localPosition.z;

        scaleDragon = new float[3];
        scaleDragon[0] = dragon.transform.localScale.x;
        scaleDragon[1] = dragon.transform.localScale.y;
        scaleDragon[2] = dragon.transform.localScale.z;

        timer = timerControler.GetStartTime();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
}
