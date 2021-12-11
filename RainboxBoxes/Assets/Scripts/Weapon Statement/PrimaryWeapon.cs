using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryWeapon : WeaponManager
{
    protected override void OnShootClicked()
    {
        Debug.Log("Shoot Primary .....");
    }
}
