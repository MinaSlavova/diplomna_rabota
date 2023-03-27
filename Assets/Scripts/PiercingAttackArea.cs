using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiercingAttackArea : MonoBehaviour
{
    private int damage;
    private int prevLevel;
    public static int damageUpgradeLevel = 0;
    private float timer = 0f;
    private float attackTime = 0f;

    private void Start()
    {
        damage = transform.GetComponentInParent<ProjectileProperties>().damage;
        
        Debug.Log("The item dmg is: " + damage);
        prevLevel = damageUpgradeLevel;
    }

    private void Update()
    {
        if (damageUpgradeLevel > prevLevel)
        {
            prevLevel = damageUpgradeLevel;
            damage = transform.GetComponentInParent<ProjectileProperties>().damage + damageUpgradeLevel;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<EnemyBehaviour>() != null)
        {
            timer += Time.deltaTime;

            if (timer >= attackTime)
            {
                timer = 0;
                attackTime = 0.1f;
                EnemyBehaviour health = other.GetComponent<EnemyBehaviour>();
                health.Damage(damage);
            }
        }
    }
}
