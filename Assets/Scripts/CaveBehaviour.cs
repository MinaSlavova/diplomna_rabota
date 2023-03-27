using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject bossEnemy;
    private bool flag = false;

    private void OnTriggerEnter(Collider other)
    {
        Vector3 spawnPoint = new Vector3(transform.position.x, 0.8f, transform.position.z);

        if (other.CompareTag("Player") && flag == false)
        {
            Instantiate(bossEnemy, spawnPoint, Quaternion.identity);
            flag = true;
        }
    }
}
