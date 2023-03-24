using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestObject : MonoBehaviour
{
    [SerializeField] private GameObject harvestDrop;
    private int dropChance;

    void Start()
    {
        dropChance = Random.Range(1, 100);
    }
    
    public void ItemHarvest()
    {
        dropChance = Random.Range(1, 100);
        if (dropChance <= 5)
        {
            Instantiate(harvestDrop, transform.position + new Vector3(0, Random.Range(0f, 1f), 0), Quaternion.identity);
        }
    }
}
