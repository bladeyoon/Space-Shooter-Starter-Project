using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Achievements
{
    private static Achievements _instance = new Achievements();
    public Dictionary<string, bool> unlocked;


    private Achievements()
    {
        string[] achievementMessage = new[]
        {
            "1st Enemy Ship", //Destroy an enemy ship, ship color 2
            "10 Enemy Ships", //Destroy 10 enemy ships, ship color 3
            "20 Enemy Ships", //Destroy 20 enemy ships, ship color 4
            "30 Enemy Ships", //Destroy 30 enemy ships, ship color 5
        };

        unlocked = new Dictionary<string, bool>();
        foreach (string m in achievementMessage)
        {
            unlocked.Add(m, false);
        }
    }

    public static Achievements Instance
    {
    get
        {
            return _instance;
        }
}
}
