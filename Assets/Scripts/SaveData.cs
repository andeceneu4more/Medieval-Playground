using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public class SaveLoad
{
    public static void SaveSystem(KnightControler knight, DragonControler dragon, TimerControler text)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/savefile.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayersData data = new PlayersData(knight, dragon, text);
        formatter.Serialize(stream, data);
        stream.Close();
    }

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
