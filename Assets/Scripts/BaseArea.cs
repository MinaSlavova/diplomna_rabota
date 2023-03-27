using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseArea : MonoBehaviour
{
    private int healing = 1;
    private GameObject player;
    [SerializeField] private float healTime = 5f;
    private float timer = 0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer += Time.deltaTime;

            if (timer >= healTime)
            {
                timer = 0;
                player.GetComponent<Health>().Heal(healing);
            }
        }
    }
}
