using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Achievements;


[System.Serializable]

public class GameData
{
    public string[] achievementsUnlocked;
    public Scores.Score[] highScores;

    public GameData()
    {
        achievementsUnlocked = new string[10];
        highScores = new Scores.Score[10];
        int index = 0;

        foreach (string key in Achievements.Instance.unlocked.Keys)
        {
            achievementsUnlocked[index] = key;
            achievementsUnlocked[index + 1] = Achievements.Instance.unlocked[key].ToString();
            index += 2;
        }
    }

    public Dictionary<string, bool> achievementsDictionary()
    {
        Dictionary<string, bool> achievementsDict = new Dictionary<string, bool>();
        for (int i = 0; i < achievementsUnlocked.Length; i++)
        {
            achievementsDict.Add(achievementsUnlocked[i], bool.Parse(achievementsUnlocked[i + 1]));
            i++;
        }
        return achievementsDict;
    }
}
