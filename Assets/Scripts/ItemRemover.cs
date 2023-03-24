using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRemover : MonoBehaviour
{
    [SerializeField] private GameObject pickup;
    public int itemFlag = 0;
    private Inventory inventory;

    public GameObject GetPickup
    {
        get { return pickup; }
    }

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (ItemPickup.itemQuantity[pickup.name + "(Clone)"] == 0)
        {
            if (pickup.CompareTag("Weapon"))
            {
                PlayerAttack.currentWeapon = 0;
            }

            inventory.isFull[itemFlag] = false;
            Destroy(gameObject);
        }
    }
}
