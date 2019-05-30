using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public class SaveLoad
{
    public static bool loading = false;

    /// <summary>
    /// static function that performs the saving process, from current 
    /// it builds a PlayersData object and serializes it in a persistent data path
    /// </summary>
    public static void SaveSystem(KnightControler knight, DragonControler dragon, TimerControler timerControler)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/savefile.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayersData data = new PlayersData(knight, dragon, timerControler);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    /// <summary>
    /// static function that performs the loading process
    /// it deserializes the data from the specific path and returns a PlayersData object
    /// </summary>
    public static PlayersData LoadSystem()
    {
        string path = Application.persistentDataPath + "/savefile.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayersData data = formatter.Deserialize(stream) as PlayersData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found " + path);
            return null;
        }
    }
}
