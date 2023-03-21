using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject appleDrop;
    [SerializeField] private GameObject stickDrop;
    private int dropChance;
    private float dropTime;
    private float timer = 0f;

    private void Start()
    {
        dropChance = Random.Range(1, 100);
        dropTime = Random.Range(1f, 200f);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= dropTime)
        {
            timer = 0;
            dropTime = Random.Range(1f, 100f);
            Instantiate(appleDrop, transform.position + new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), 0), Quaternion.identity);
        }
    }

    public void ItemHarvest()
    {
        dropChance = Random.Range(1, 100);
        if (dropChance <= 5)
        {
            Instantiate(stickDrop, transform.position + new Vector3(0, Random.Range(0f, 1f), 0), Quaternion.identity);
        }
    }
}
