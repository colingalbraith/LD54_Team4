using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager _dm;
    public static DataManager DM
    {
        get
        {
            if (_dm == null)
                Debug.LogError("Data Manager is down");
            return _dm;
        }
    }

    private string saveFile;
    
    private void Start()
    {
        saveFile = Application.persistentDataPath + "/Data.json";
        _dm = this;
    }

    public GameData Read()
    {
        if (File.Exists(saveFile))
        {
            string content = File.ReadAllText(saveFile);
            return JsonUtility.FromJson<GameData>(content);
        }
        return new GameData();
    }

    public void Write(GameData data)
    {
        string strData = JsonUtility.ToJson(data);
        File.WriteAllText(saveFile, strData);
    }
}

[System.Serializable]
public class GameData
{
    public const int LEVEL_NUM = 3;
    public bool[] completed = new bool[LEVEL_NUM];
}
