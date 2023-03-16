using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    public TMP_Text healthText;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Health playerHealth = player.GetComponent<Health>();
        healthText.text = "HEALTH: " + playerHealth.CurrentHealth + "\nLIVES: " + playerHealth.CurrentLives;
    }
}
