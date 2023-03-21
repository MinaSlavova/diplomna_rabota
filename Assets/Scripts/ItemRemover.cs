using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRemover : MonoBehaviour
{
    [SerializeField] private GameObject pickup;
    public int itemFlag = 0;
    private Inventory inventory;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (ItemPickup.itemQuantity[pickup.name + "(Clone)"] == 0)
        {
            inventory.isFull[itemFlag] = false;
            Destroy(gameObject);
        }
    }
}
