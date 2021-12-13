using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtWeaponInfo;
    [SerializeField] private TextMeshProUGUI txtWeaponAmmo;
    [SerializeField] private GameObject ammoType;

    public void PrintWeaponData(WeaponData weaponData)
    {
        txtWeaponInfo.text = "Type : " + weaponData.Type + "\n Reload Time : " + weaponData.ReloadTime +
            "\n Weapon Firerate : " + weaponData.FireRate + "\n Weapon Firerate : " + weaponData.BaseDamage;
    }

    public void PrintWeaponAmmo(WeaponData weaponData)
    {
        txtWeaponAmmo.text = weaponData.AmmoLeft + "/" + weaponData.TotalWeaponAmmo;
    }
}

