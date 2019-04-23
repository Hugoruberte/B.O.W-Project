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
        leaderboard.playerScores = new Dictionary<string, float>();

        leaderboard = LoadGame();
    }

    void Update()
    {
        //example of utlisation
        /*if (Input.GetKeyDown(KeyCode.V))
        {
            AddScore("roger", 100);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            AddScore("s", 120);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            AddScore("d", 150);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveGame();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Dictionary<string, float> tmp;
            tmp = GetSortedLeaderBoard();
            foreach(string s in tmp.Keys)
            {
                Debug.Log("player score:");
                Debug.Log(s);
                Debug.Log(tmp[s]);
            }
        }*/
    }

    //leaderboard update
    public void AddScore(string name, float score)
    {
        if (leaderboard.playerScores.ContainsKey(name))
        {
            if (leaderboard.playerScores[name] < score)
            {
                leaderboard.playerScores[name] = score;
            }
        }
        else
        {
            leaderboard.playerScores.Add(name, score);
        }
    }


    //give a sort array
    public Dictionary<string, float> GetSortedLeaderBoard()
    {
        Dictionary<string, float> copyLeaderBoard = new Dictionary<string, float>(leaderboard.playerScores);

        Dictionary<string, float> sortedDictionary = new Dictionary<string, float>();

        while (copyLeaderBoard.Keys.Count > 0)
        {
            string maxName = "";
            float maxValue = -1;
            foreach(string s in copyLeaderBoard.Keys)
            {
                if(maxValue == -1 || maxValue < copyLeaderBoard[s])
                {
                    maxName = s;
                    maxValue = copyLeaderBoard[s];
                }
            }

            sortedDictionary.Add(maxName, maxValue);

            copyLeaderBoard.Remove(maxName);
     
        }

        return sortedDictionary;
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
