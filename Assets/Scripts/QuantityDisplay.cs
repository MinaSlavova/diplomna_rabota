using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuantityDisplay : MonoBehaviour
{
    public TMP_Text quantityText;
    [SerializeField] private GameObject pickup;

    private string itemName;

    private void Start()
    {
        itemName = pickup.name;
    }

    void Update()
    {
        if (ItemPickup.itemQuantity[pickup.name + "(Clone)"] > 0)
        {
            quantityText.text = "x" + ItemPickup.itemQuantity[pickup.name + "(Clone)"];
        }
    }
}
