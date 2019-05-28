using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigureLoad : MonoBehaviour
{
    public KnightControler knight;
    public DragonControler dragon;
    public TimerControler text;
    void Awake()
    {
        Debug.Log("Wake Up");
        if (SaveLoad.loading)
        {
            SaveLoad.loading = false;
            PlayersData data = SaveLoad.LoadSystem();
            knight.transform.localPosition = new Vector3(data.positionKnight[0], data.positionKnight[1], data.positionKnight[2]);
            knight.transform.localScale = new Vector3(data.scaleKnight[0], data.scaleKnight[1], data.scaleKnight[2]);
            dragon.transform.localPosition = new Vector3(data.positionDragon[0], data.positionDragon[1], data.positionDragon[2]);
            dragon.transform.localScale = new Vector3(data.scaleDragon[0], data.scaleDragon[1], data.scaleDragon[2]);
            text.timerText.text = data.timerText;
        }
    }

}
