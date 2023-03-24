using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage;
    private int prevLevel;
    public static int damageUpgradeLevel = 0;

    private void Start()
    {
        damage = transform.GetComponentInParent<WeaponProperties>().damage;
        Debug.Log("The item dmg is: " + damage);
        prevLevel = damageUpgradeLevel;
    }

    private void Update()
    {
        if (damageUpgradeLevel > prevLevel)
        {
            prevLevel = damageUpgradeLevel;
            damage = transform.GetComponentInParent<WeaponProperties>().damage + damageUpgradeLevel;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Harvestable") )
        {
            HarvestObject harvestable = other.GetComponent<HarvestObject>();
            harvestable.ItemHarvest();
        }
        else if (other.GetComponent<EnemyBehaviour>() != null)
        {
            EnemyBehaviour health = other.GetComponent<EnemyBehaviour>();
            health.Damage(damage);
        }
    }
}
