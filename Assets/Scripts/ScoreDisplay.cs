using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TMP_Text scoreText;

    private void Update()
    {
        scoreText.text = string.Format("SCORE: {0:00000}", Score.score);
    }
}
