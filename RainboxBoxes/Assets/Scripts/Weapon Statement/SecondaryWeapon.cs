using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryWeapon : WeaponManager
{
    protected override void OnShootClicked()
    {
        Debug.Log("Shoot Secondary .....");
    }
}