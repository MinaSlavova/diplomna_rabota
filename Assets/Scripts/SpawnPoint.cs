using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private float repeatTime;

    void Start()
    {
        repeatTime = Random.Range(5f, 21f);
        InvokeRepeating("Spawn", 5f, repeatTime);
    }

    void Spawn()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-20, 21), 1, Random.Range(-20, 21));
        Instantiate(prefab, randomSpawnPosition, Quaternion.identity);
    }
}
