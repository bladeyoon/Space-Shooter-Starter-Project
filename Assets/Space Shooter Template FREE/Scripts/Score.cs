using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    public string name;
    public double score;

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
