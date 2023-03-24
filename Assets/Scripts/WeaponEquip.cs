using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEquip : MonoBehaviour
{
    public void EquipWeapon(int weaponIndex)
    {
        PlayerAttack.currentWeapon = weaponIndex;
    }
}
