using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject player;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Home()
    {
        player.GetComponent<ScoreManager>().AddScore(System.DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"), string.Format("{0:00000}", Score.score));
        PlayerMovement.moveSpeedUpgradeLevel = 0;
        Health.healthUpgradeLevel = 0;
        AttackArea.damageUpgradeLevel = 0;
        Score.score = 0;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1f;
    }
}
