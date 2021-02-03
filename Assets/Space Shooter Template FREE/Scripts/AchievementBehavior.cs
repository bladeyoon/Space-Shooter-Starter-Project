using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Analytics;

public class AchievementBehavior : MonoBehaviour
{
    public GameObject[] unlockableObjects;
    public LevelController levelController;
    public Player player;
    PlayerShooting ps;
    public int enemiesDestroyed;
    public TextMeshProUGUI unlockedText;
    Achievements achievements;
    public GameObject achievementScreen;

    private void Awake()
    {
        ps = player.GetComponent <PlayerShooting>();
        achievements = Achievements.Instance;
    }

    void checkEnemyAchivement()
    {
        int livesLeft = player.jump;
        //count number of enemies that were destroyed
        enemiesDestroyed++;
        if (enemiesDestroyed == 1)
        {
            if (!(livesLeft == 0))
            {
                achievements.unlocked["1st Enemy Ship"] = true;
                DisplayAchievement("1st Enemy Ship");
            }
        }

        if (enemiesDestroyed == 10)
        {
            if (!(livesLeft == 0))
            {
                achievements.unlocked["10 Enemy Ships"] = true;
                DisplayAchievement("10 Enemy Ships");
            }
        }

        if (enemiesDestroyed == 20)
        {
            if (!(livesLeft == 0))
            {
                achievements.unlocked["20 Enemy Ships"] = true;
                DisplayAchievement("20 Enemy Ships");
            }
        }    

        if (enemiesDestroyed == 30)
        {
            if (!(livesLeft == 0))
            {
                achievements.unlocked["30 Enemy Ships"] = true;
                DisplayAchievement("30 Enemy Ships");
            }
        }

    }

    void DisplayAchievement(string Name)
    {
        ReportAchievement(Name);
        unlockedText.text = Name;
        //achievementScreen.SetActive(true);
        unlockedText.transform.parent.GetComponent<Canvas>().enabled = true;
        Debug.Log("Achievement Screen is on");
        StartCoroutine(waitForTime(3));
    }

    IEnumerator waitForTime(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        //achievementScreen.SetActive(false);
        unlockedText.transform.parent.GetComponent<Canvas>().enabled = false;
    }

    public void ReportAchievement(string achievement)
    {
        Analytics.CustomEvent("achievement_unlocked", new Dictionary<string, object>
        {
            { "achievement_id", achievement }, 
            {"time_elapsed", Time.timeSinceLevelLoad }
        });
    }
}
