using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeaponBehaviour : MonoBehaviour
{
    private Transform projectileSpawnPoint;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 5;
    private Animator anim;
    private bool attacking = false;
    private float timer = 0f;

    private void Start()
    {
        projectileSpawnPoint = transform.Find("ProjectileSpawn");
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !attacking)
        {
            Attack();
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= projectilePrefab.GetComponent<ProjectileProperties>().attackTime)
            {
                timer = 0;
                anim.SetBool("Attacking", false);
                attacking = false;
            }
        }
    }

    private void Attack()
    {
        attacking = true;
        anim.SetBool("Attacking", true);
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
        projectile.GetComponent<Rigidbody>().velocity = projectileSpawnPoint.forward * projectileSpeed;
    }
}
