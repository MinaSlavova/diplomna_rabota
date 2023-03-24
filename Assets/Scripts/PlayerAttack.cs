using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public static int currentWeapon = 0;
    private int prevWeapon;

    void Start()
    {
        prevWeapon = currentWeapon;
    }

    void Update()
    {
        if(prevWeapon != currentWeapon)
        {
            transform.GetChild(prevWeapon).gameObject.SetActive(false);
            transform.GetChild(currentWeapon).gameObject.SetActive(true);
            prevWeapon = currentWeapon;
        }
    }
}
