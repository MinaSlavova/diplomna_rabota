using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUpgradeShop : MonoBehaviour
{
    [SerializeField] private UpgradesScreen upgradesScreen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            upgradesScreen.Show();
            Time.timeScale = 0.5f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            upgradesScreen.Hide();
            Time.timeScale = 1f;
        }
    }
}
