using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float repeatTime = 5f;
    [SerializeField] private float startTime = 5f;

    void Start()
    {
        InvokeRepeating("Spawn", startTime, repeatTime);
    }

    void Spawn()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-20, 21), 1, Random.Range(-20, 21));
        Instantiate(prefab, randomSpawnPosition, Quaternion.identity);
    }
}
