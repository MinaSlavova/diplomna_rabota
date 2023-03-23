using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage;
    private int prevLevel;
    public static int damageUpgradeLevel = 1;

    private void Start()
    {
        damage = transform.GetChild(0).GetComponent<WeaponProperties>().damage;
        Debug.Log("The item dmg is: " + damage);
        prevLevel = damageUpgradeLevel;
    }

    private void Update()
    {
        if (damageUpgradeLevel > prevLevel)
        {
            prevLevel = damageUpgradeLevel;
            damage = transform.GetChild(0).GetComponent<WeaponProperties>().damage + damageUpgradeLevel - 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            TreeBehaviour tree = other.GetComponent<TreeBehaviour>();
            tree.ItemHarvest();
        }
        else if (other.GetComponent<EnemyBehaviour>() != null)
        {
            EnemyBehaviour health = other.GetComponent<EnemyBehaviour>();
            health.Damage(damage);
        }
    }
}
