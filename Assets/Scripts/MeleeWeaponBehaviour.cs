using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponBehaviour : MonoBehaviour
{
    private GameObject attackArea = default;
    private Animator anim;
    private bool attacking = false;
    private float timer = 0f;

    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !attacking)
        {

            Attack();
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= gameObject.GetComponent<WeaponProperties>().attackTime)
            {
                timer = 0;
                attacking = false;
                anim.SetBool("Attacking", false);
                attackArea.SetActive(attacking);
            }
        }
    }

    private void Attack()
    {
        attacking = true;
        anim.SetBool("Attacking", true);
        attackArea.SetActive(attacking);
    }
}
