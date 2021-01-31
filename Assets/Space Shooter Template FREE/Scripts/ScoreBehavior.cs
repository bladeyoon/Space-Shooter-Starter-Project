using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreBehavior : MonoBehaviour
{
    public LevelController levelController;
    public Scores.Score playerScoreObject;                              // reference to the Player UI
    public Canvas newHighScoreUI;                                   // reference to New High Score UI
    public Canvas highScoreUI;                                      // reference to High Score UI
    public TMPro.TMP_InputField playerName;                             // reference to TMPro Text inputfield Component
    public TMPro.TMP_Text[] scoresTextList = new TMPro.TMP_Text[10];    // best 10 scores will shown

    // Start is called before the first frame update

    public void Awake()
    {
        //newHighScoreUI = GetComponent<Canvas>();
        //highScoreUI = GetComponent<Canvas>();
    }

    static Scores.Score[] SortScores(Scores.Score[] scores)
    {
        for (int i = 0; i < scores.Length - 1; i++)
        {
            for (int j = i + 1; j > 0; j--)
            {
                if (scores[j - 1].score > scores[j].score)
                {
                    Scores.Score temp = scores[j - 1];
                    scores[j - 1] = scores[j];
                    scores[j] = temp;
                }
            }
        }
        return scores;
    }

    // checks the new score is one of the highest scores.
    public bool isHighScore(Scores.Score newScore)
    {
        foreach (Scores.Score score in Scores.Instance.scores)
        {
            if (newScore.score > score.score)
            {
                return true;
            }
        }
        return false;
    }

    // add new score into array and if it is high score, remove the lowest score.
    public void addNewScore(Scores.Score newScore)
    {
        //remove the lowest score;
        Scores.Score[] scores = SortScores(Scores.Instance.scores);
        scores[0] = newScore;
        Scores.Instance.scores = SortScores(scores);
    }

    public void CheckPlayerScore()
    {
        Debug.Log("Checking Player Score");
        double currentScore = levelController.GetCurrentScore();
        playerScoreObject.score = currentScore;
        if (isHighScore(playerScoreObject))
        {
            Debug.Log("Display New High Score");
            DisplayNewHighScore();
        }
        else
        {
            Debug.Log("DisplayHighScore");
            StartCoroutine(DisplayHighScore());
        }
    }

    public void DisplayNewHighScore()
    {
        newHighScoreUI.GetComponent<Canvas>().enabled = true;
        playerName.enabled = true;
    }

    public void UpdateHighScoresAndDisplayHighScores()
    {
        playerName.enabled = false;
        playerScoreObject.name = playerName.text;
        if (playerScoreObject.score !=0)
        {
            addNewScore(playerScoreObject);
        }
        newHighScoreUI.GetComponent<Canvas>().enabled = false;
        StartCoroutine(DisplayHighScore());
    }

    public IEnumerator DisplayHighScore()
    {
        UpdateHighScoreText();
        highScoreUI.GetComponent<Canvas>().enabled = true;
        Debug.Log("High Score UI is active now.");
        yield return new WaitForSeconds(10);

        highScoreUI.GetComponent<Canvas>().enabled = false;
        levelController.Save();

        Debug.Log("Stopping all coroutines");
        StopAllCoroutines();

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void UpdateHighScoreText()
    {
        Scores.Instance.scores = SortScores(Scores.Instance.scores);
        int rowIndex = 0;
        for (int scoreIndex = scoresTextList.Length-1; scoreIndex >= 0; scoreIndex--)
        {
            scoresTextList[rowIndex].text = (rowIndex + 1) + 
                "." + Scores.Instance.scores[scoreIndex].name +
                " " + Scores.Instance.scores[scoreIndex].score;
            rowIndex++;
        }
    }
}
