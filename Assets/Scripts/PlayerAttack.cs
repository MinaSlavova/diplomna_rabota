using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;
    private GameObject weapon = default;
    public static int currentWeapon = 0;
    private bool attacking = false;
    private float timer = 0f;
    private int prevWeapon;

    void Start()
    {
        attackArea = transform.GetChild(currentWeapon).gameObject;
        weapon = transform.GetChild(currentWeapon).GetChild(0).gameObject;
        prevWeapon = currentWeapon;
    }

    void Update()
    {
        if(prevWeapon != currentWeapon)
        {
            attackArea.SetActive(false);
            attackArea = transform.GetChild(currentWeapon).gameObject;
            weapon = transform.GetChild(currentWeapon).GetChild(0).gameObject;
            prevWeapon = currentWeapon;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if(timer >= weapon.GetComponent<WeaponProperties>().attackTime)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
    }

    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }
}
