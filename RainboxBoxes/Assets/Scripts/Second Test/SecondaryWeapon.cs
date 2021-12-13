using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryWeapon : WeaponManager
{
    protected override void OnShootClicked()
    {
        base.OnShootClicked();
        Debug.Log("Shoot Secondary .....");
        uiManager.PrintWeaponAmmo(weaponData);
    }
}