using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class LeaderBoardSaver : Singleton<LeaderBoardSaver>
{
    private LeaderBoard leaderboard;

    const string folderName = "BinaryLeaderBoardData";
    const string fileName = "leaderboard";
    const string fileExtension = ".dat";

    private void Start()
    {
        leaderboard = new LeaderBoard();
        leaderboard.playerScores = new List<float>();

        leaderboard = LoadGame();
    }


    //leaderboard update
    public void AddScore(float score)
    {
        int i = 0;
        bool found = false;
        while( i < leaderboard.playerScores.Count && !found)
        {
            if (leaderboard.playerScores[i] < score)
            {
                leaderboard.playerScores.Insert(i, score);
                found = true;
            }
        }
        SaveGame();
            
    }


    //give a sort array
    public List<float> GetSortedLeaderBoard()
    {
        return leaderboard.playerScores;
    }


    //save & load
    public void SaveGame()
    {
        string folderPath = Path.Combine(Application.persistentDataPath, folderName);
        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        string dataPath = Path.Combine(folderPath, fileName + fileExtension);
        SaveScore(leaderboard, dataPath);
    }

    public LeaderBoard LoadGame()
    {
        string folderPath = Path.Combine(Application.persistentDataPath, folderName);
        string dataPath = Path.Combine(folderPath, fileName + fileExtension);

        if (File.Exists(dataPath))
            leaderboard = LoadScore(dataPath);

        return leaderboard;
    }


    //score handling
    void SaveScore(LeaderBoard data, string path)
    {
        
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        using (FileStream fileStream = File.Open(path, FileMode.OpenOrCreate))
        {
            binaryFormatter.Serialize(fileStream, data);
        }
    }

    LeaderBoard LoadScore(string path)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        using (FileStream fileStream = File.Open(path, FileMode.Open))
        {
            return (LeaderBoard)binaryFormatter.Deserialize(fileStream);
        }
    }

}
