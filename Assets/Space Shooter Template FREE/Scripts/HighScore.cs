using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public GameObject highScoreUI;

    public Score playerScore;

    public bool isHighScore(Score newScore)
    {
        foreach (Score score in Scores.Instance.scores)
        {
            if (newScore.score > score.score)
            {
                return true;
            }
        }
        return false;
    }

    public void addNewScore(Score newScore)
    {
        Score[] scores = new Score[10];
        scores[0] = newScore;
        Scores.Instance.scores = scores;
    }
}
