using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreboardDisplay : MonoBehaviour
{
    public ScoreManager scoreManager;
    public int scoreIndex;

    private TMP_Text dateText;
    private TMP_Text scoreText;

    void Start()
    {
        dateText = transform.GetChild(0).GetComponent<TMP_Text>();
        scoreText = transform.GetChild(1).GetComponent<TMP_Text>();

        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        if (scoreManager.scores.Count > scoreIndex)
        {
            ScoreData scoreData = scoreManager.scores[scoreIndex];
            dateText.text = scoreData.date;
            scoreText.text = "Score: " + scoreData.score;
        }
    }
}
