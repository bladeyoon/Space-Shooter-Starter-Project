using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


//This script stores the top 10 scores with name locally

[Serializable]
public class Scores
{
    private static Scores _instance = new Scores();
    public Score[] scores;      // scores array

    private Scores()
    {
        scores = new Score[10]; //show first 10 scores;
        for (int i = 0; i < scores.Length; i++)
        {
            scores[i] = new Score();
        }
    }

    public static Scores Instance
    {
        get
        {
            return _instance;
        }
    }


    [Serializable]
    public class Score
    {
        public string name;             // the player name
        public double score;            // the player score

        public Score()
        {
            name = "";
            score = 0;
        }

        public Score(string name, double score)
        {
            this.name = name;
            this.score = score;
        }
    }
}
