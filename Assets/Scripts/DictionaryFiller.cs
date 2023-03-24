using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryFiller : MonoBehaviour
{
    [SerializeField] private GameObject[] items;

    private void Awake()
    {
        for(int i = 0; i < items.Length; i++)
        {
            ItemPickup.itemQuantity.TryAdd(items[i].name + "(Clone)", 0);
        }
    }

    private void Start()
    {
        ItemPickup.itemQuantity["Sword(Clone)"] = 1;
    }
}
