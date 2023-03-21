using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    static public Dictionary<string, int> itemQuantity = new Dictionary<string, int>();

    private string itemName;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        itemName = gameObject.name;
        itemQuantity.TryAdd(itemName, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("The item name is: " + gameObject.name);
            if (itemQuantity[itemName] > 0)
            {
                int count = itemQuantity[itemName];
                count++;
                itemQuantity[itemName] = count;
                Destroy(gameObject);
            }
            else
            {
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.isFull[i] == false)
                    {
                        inventory.isFull[i] = true;
                        GameObject button = Instantiate(itemButton, inventory.slots[i].transform, false);
                        button.GetComponent<ItemRemover>().itemFlag = i;
                        itemQuantity[itemName] = 1;
                        Destroy(gameObject);
                        break;
                    }
                }
            }
        }
    }
}
