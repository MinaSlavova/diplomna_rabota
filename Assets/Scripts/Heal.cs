using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    private int healing = 4;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void HealHealth()
    {
        int count = ItemPickup.itemQuantity["AppleItem(Clone)"];
        if (count > 0 && player.GetComponent<Health>().CurrentHealth < player.GetComponent<Health>().GetMAX_HEALTH) {
            player.GetComponent<Health>().Heal(healing);
            count -= 1;
            ItemPickup.itemQuantity["AppleItem(Clone)"] = count;
        }
    }
}
