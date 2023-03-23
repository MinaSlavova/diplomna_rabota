using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class ScoreData
{
    public string date;
    public string score;
}

public class ScoreManager : MonoBehaviour
{
    public List<ScoreData> scores = new List<ScoreData>();
    public string saveFileName = "HighScores.dat";

    void Start()
    {
        LoadScores();
    }

    public void AddScore(string date, string score)
    {
        ScoreData newScore = new ScoreData();
        newScore.date = date;
        newScore.score = score;
        scores.Add(newScore);

        scores.Sort((x, y) => y.score.CompareTo(x.score));

        SaveScores();
    }

    public void SaveScores()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + saveFileName);
        bf.Serialize(file, scores);
        file.Close();
    }

    public void LoadScores()
    {
        if (File.Exists(Application.persistentDataPath + "/" + saveFileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + saveFileName, FileMode.Open);
            scores = (List<ScoreData>)bf.Deserialize(file);
            file.Close();
        }
    }
}
