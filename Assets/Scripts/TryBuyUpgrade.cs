using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TryBuyUpgrade : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private GameObject rapierButton;
    [SerializeField] private GameObject lanceButton;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    public void Buy()
    {
        int.TryParse(transform.GetChild(1).Find("Price").GetComponent<TextMeshProUGUI>().text, out int upgradeCostA);
        int.TryParse(transform.GetChild(2).Find("Price").GetComponent<TextMeshProUGUI>().text, out int upgradeCostS);
        int.TryParse(transform.GetChild(3).Find("Price").GetComponent<TextMeshProUGUI>().text, out int upgradeCostR);
        BuyUpgrade(transform.Find("UpgradeName").GetComponent<TextMeshProUGUI>().text, upgradeCostA, upgradeCostS, upgradeCostR);
    }

    private void BuyUpgrade(string upgradeName, int upgradeCostA, int upgradeCostS, int upgradeCostR)
    {
        if (upgradeName.Equals("Health") && DeductCost(upgradeCostA, upgradeCostS, upgradeCostR) == true)
        {
            Health.healthUpgradeLevel += 1;
        }
        else if (upgradeName.Equals("Speed") && DeductCost(upgradeCostA, upgradeCostS, upgradeCostR) == true)
        {
            PlayerMovement.moveSpeed += 0.5f;
        }
        else if (upgradeName.Equals("Attack") && DeductCost(upgradeCostA, upgradeCostS, upgradeCostR) == true)
        {
            AttackArea.damageUpgradeLevel += 1;
        }
        else if (upgradeName.Equals("Rapier") && ItemPickup.itemQuantity["Rapier(Clone)"] != 1)
        {
            InventoryCheck("Rapier(Clone)", rapierButton, upgradeCostA, upgradeCostS, upgradeCostR);
        }
        else if (upgradeName.Equals("Lance") && ItemPickup.itemQuantity["Lance(Clone)"] != 1)
        {
            InventoryCheck("Lance(Clone)", lanceButton, upgradeCostA, upgradeCostS, upgradeCostR);
        }
    }

    private bool DeductCost(int upgradeCostA, int upgradeCostS, int upgradeCostR)
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
            return true;
        }
        return false;
    }

    private void InventoryCheck(string itemName, GameObject itemButton, int upgradeCostA, int upgradeCostS, int upgradeCostR)
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                if (DeductCost(upgradeCostA, upgradeCostS, upgradeCostR) == true)
                {
                    inventory.isFull[i] = true;
                    GameObject button = Instantiate(itemButton, inventory.slots[i].transform, false);
                    ItemPickup.itemQuantity[itemName] = 1;
                    button.GetComponent<ItemRemover>().itemFlag = i;
                }
                break;
            }
        }
    }
}
