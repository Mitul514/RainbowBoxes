using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public enum WeaponType { Primary, Secondary, None};

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/WeaponData")]
public class WeaponData : ScriptableObject
{
    public WeaponType Type;
    public int TotalWeaponAmmo;
    public int AmmoLeft;
    public float ReloadTime;
}
