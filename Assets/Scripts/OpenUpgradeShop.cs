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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            upgradesScreen.Hide();
        }
    }
}
