using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 20;
    [SerializeField] private int MAX_HEALTH = 20;
    private GameObject respawnPoint;

    private void Start()
    {
        respawnPoint = GameObject.FindGameObjectWithTag("Respawn");
    }

    public int CurrentHealth
    {
        get { return health; }
    }

    public void Damage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        if (gameObject.CompareTag("Player"))
        {
            gameObject.transform.position = respawnPoint.transform.position;
            health = MAX_HEALTH;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
