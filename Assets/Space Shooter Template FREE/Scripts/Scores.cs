using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scores
{
    private static Scores _instance = new Scores();

    public Score[] scores;

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
}
