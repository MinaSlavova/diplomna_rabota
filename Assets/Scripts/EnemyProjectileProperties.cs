using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileProperties : MonoBehaviour
{
    public int damage = 5;
    private float timer = 0f;
    private float attackTime = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 5f)
        {
            timer = 0;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer += Time.deltaTime;

            if (timer >= attackTime)
            {
                timer = 0;
                attackTime = 0.1f;
                other.gameObject.GetComponent<Health>().Damage(damage);
            }
        }
    }
}
