using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static float score;
    private float pointsPerSecond = 10f;

    private void Update()
    {
        score += pointsPerSecond * Time.deltaTime;
    }
}
