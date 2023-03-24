using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptySlot : MonoBehaviour
{

    [SerializeField] private GameObject[] itemDrops;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void DropItem()
    {
        if(transform.childCount > 1)
        {
            ItemDrop(transform.GetChild(1).gameObject.GetComponent<ItemRemover>().GetPickup.name + "(Clone)");
        }
    }

    public void ItemDrop(string itemName)
    {
        for (int i = 0; i < itemDrops.Length; i++)
        {
            if ((itemDrops[i].name + "(Clone)") == itemName)
            {
                for (int j = 0; j < ItemPickup.itemQuantity[itemName]; j++)
                {
                    Instantiate(itemDrops[i], player.position + new Vector3(Random.Range(0f, 1f), 1, 0), Quaternion.identity);
                }
                ItemPickup.itemQuantity[itemName] = 0;
                break;
            }
            
        }
    }
}
