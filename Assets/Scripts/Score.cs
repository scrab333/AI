﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.MLAgents;
using UnityEngine;


/*
 * Singleton to globally collect the Scores of all Players.
 * When a new Highscore is reached, it is added to Tensorboard.
 */
public class Score : MonoBehaviour
{
    public static Score Instance; 

    [SerializeField] private TextMeshProUGUI botScore;
    [SerializeField] private TextMeshProUGUI playerScore;
    
    private StatsRecorder statsRecorder;
    private int highScore = 0;
    void Awake()
    {
        Instance = this;
        //statsRecorder = Academy.Instance.StatsRecorder;
    }

    public void AddScoreBot(int score)
    {
        if (score > highScore)
        {
            highScore = score;
            botScore.text = score.ToString();
            //statsRecorder.Add("High Score", highScore, StatAggregationMethod.MostRecent);
        }

    }

    public void AddScorePlayer(int score)
    {
        if (score > highScore)
        {
            highScore = score;
            botScore.text = score.ToString();
            //statsRecorder.Add("High Score", highScore, StatAggregationMethod.MostRecent);
        }

    }

}
