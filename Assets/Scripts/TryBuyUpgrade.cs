using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TryBuyUpgrade : MonoBehaviour
{
    public void Buy()
    {
        int.TryParse(transform.GetChild(1).Find("Price").GetComponent<TextMeshProUGUI>().text, out int upgradeCostA);
        int.TryParse(transform.GetChild(2).Find("Price").GetComponent<TextMeshProUGUI>().text, out int upgradeCostS);
        int.TryParse(transform.GetChild(3).Find("Price").GetComponent<TextMeshProUGUI>().text, out int upgradeCostR);
        BuyUpgrade(transform.Find("UpgradeName").GetComponent<TextMeshProUGUI>().text, upgradeCostA, upgradeCostS, upgradeCostR);
    }

    private void BuyUpgrade(string upgradeName, int upgradeCostA, int upgradeCostS, int upgradeCostR)
    {
        if (ItemPickup.itemQuantity["AppleItem(Clone)"] >= upgradeCostA && ItemPickup.itemQuantity["StickItem(Clone)"] >= upgradeCostS && ItemPickup.itemQuantity["RockItem(Clone)"] >= upgradeCostR)
        {
            int countA = ItemPickup.itemQuantity["AppleItem(Clone)"];
            int countS = ItemPickup.itemQuantity["StickItem(Clone)"];
            int countR = ItemPickup.itemQuantity["RockItem(Clone)"];

            countA -= upgradeCostA;
            countS -= upgradeCostS;
            countR -= upgradeCostR;

            ItemPickup.itemQuantity["AppleItem(Clone)"] = countA;
            ItemPickup.itemQuantity["StickItem(Clone)"] = countS;
            ItemPickup.itemQuantity["RockItem(Clone)"] = countR;

            if (upgradeName.Equals("Health"))
            {
                Health.healthUpgradeLevel += 1;
            }
            else if (upgradeName.Equals("Speed"))
            {
                PlayerMovement.moveSpeed += 0.5f;
            }
            else if (upgradeName.Equals("Attack"))
            {
                AttackArea.damageUpgradeLevel += 1;
            }
            else if (upgradeName.Equals("Rapier") && PlayerAttack.currentWeapon != 1)
            {
                PlayerAttack.currentWeapon = 1;
            }
            else if (upgradeName.Equals("Lance") && PlayerAttack.currentWeapon != 2)
            {
                PlayerAttack.currentWeapon = 2;
            }
        }
    }
}
