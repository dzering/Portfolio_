using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController
{
    TextView scoreView;
    int count;
    bool isCount;

    public ScoreController(TextView score)
    {

        scoreView = score;
    }
    public bool Update()
    {
        count++;
        scoreView.Text.text = $"Steps: {count}";
        return isCount == true;
    }
}
