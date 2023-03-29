using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        ResetStatic();
    }

    public void Home()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1f;
        ResetStatic();
    }

    private void ResetStatic()
    {
        PlayerMovement.moveSpeedUpgradeLevel = 0;
        Health.healthUpgradeLevel = 0;
        AttackArea.damageUpgradeLevel = 0;
        Score.score = 0;
    }
}
