using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUpgradeShop : MonoBehaviour
{
    [SerializeField] private UpgradesScreen upgradesScreen;

    private void Start()
    {
        ItemPickup.itemQuantity.TryAdd("AppleItem(Clone)", 0);
        ItemPickup.itemQuantity.TryAdd("StickItem(Clone)", 0);
        ItemPickup.itemQuantity.TryAdd("RockItem(Clone)", 0);
    }

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
