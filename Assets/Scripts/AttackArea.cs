using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public static int damage = 3;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Health>() != null)
        {
            Health health = other.GetComponent<Health>();
            health.Damage(damage);
        }
    }
}
