using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileProperties : MonoBehaviour
{
    public int damage = 3;
    public float attackTime = 0.2f;
    private float timer = 0f;

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
        if (other.GetComponent<EnemyBehaviour>() != null)
        {
            if (gameObject.GetComponentInChildren<AttackArea>() != null)
            {
                Destroy(gameObject);
            }   
        }
    }
}
