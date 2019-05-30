using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigureLoad : MonoBehaviour
{
    public KnightControler knight;
    public DragonControler dragon;
    public TimerControler timerControler;

    /// <summary>
    /// When the scene is load, the characters are put in the latest configuration and the timer start from the latest save 
    /// </summary>
    void Awake()
    {
        if (SaveLoad.loading)
        {
            SaveLoad.loading = false;
            PlayersData data = SaveLoad.LoadSystem();
            knight.transform.localPosition = new Vector3(data.positionKnight[0], data.positionKnight[1], data.positionKnight[2]);
            knight.transform.localScale = new Vector3(data.scaleKnight[0], data.scaleKnight[1], data.scaleKnight[2]);
            dragon.transform.localPosition = new Vector3(data.positionDragon[0], data.positionDragon[1], data.positionDragon[2]);
            dragon.transform.localScale = new Vector3(data.scaleDragon[0], data.scaleDragon[1], data.scaleDragon[2]);
            timerControler.SetStartTime(data.timer);
        }
        else
            timerControler.SetStartTime(Time.time);
    }

}
