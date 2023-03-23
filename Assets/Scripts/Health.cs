using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen; 
    [SerializeField] private int health = 100;
    private int MAX_HEALTH = 100;
    public static int healthUpgradeLevel = 1;
    private int lives = 2;
    private int prevLevel;
    private GameObject respawnPoint;

    private void Start()
    {
        respawnPoint = GameObject.FindGameObjectWithTag("Respawn");
        prevLevel = healthUpgradeLevel;
    }

    private void Update()
    {
        if (healthUpgradeLevel > prevLevel)
        {
            prevLevel = healthUpgradeLevel;
            MAX_HEALTH += 20;
        }
    }

    public int CurrentHealth
    {
        get { return health; }
    }

    public int CurrentLives
    {
        get { return lives; }
    }

    public int GetMAX_HEALTH
    {
        get { return MAX_HEALTH; }
    }

    public void Damage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Death();
        }
    }

    public void Heal(int amount)
    {
        if(health < MAX_HEALTH)
        {
            health += amount;
            if(health > MAX_HEALTH)
            {
                health = MAX_HEALTH;
            }
        }
    }

    private void Death()
    {
        if (lives != 1)
        {
            gameObject.transform.position = respawnPoint.transform.position;
            health = MAX_HEALTH;
            lives--;
        }
        else
        {
            gameObject.GetComponent<ScoreManager>().AddScore(System.DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"), string.Format("{0:00000}", Score.score));
            deathScreen.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
