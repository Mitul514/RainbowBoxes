using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponManager : MonoBehaviour
{
    [SerializeField] protected WeaponData weaponData;
    [SerializeField] protected PlayerManager playerManager;
   
    protected int TotalAmmo { get => weaponData.TotalWeaponAmmo; }

    private void OnEnable()
    {
        playerManager.OnShootSignal += OnShootClicked;
        playerManager.OnWeapoReload += ReloadWeapon;
    }

    private void OnDisable()
    {
        playerManager.OnShootSignal -= OnShootClicked;
        playerManager.OnWeapoReload -= ReloadWeapon;
    }

    protected abstract void OnShootClicked();
   
    protected void ReloadWeapon()
    {
        StartCoroutine(ReloadAfterDelay(weaponData.ReloadTime));
    }

    private IEnumerator ReloadAfterDelay(float delay)
    { 
        yield return new WaitForSeconds(delay);
        weaponData.TotalWeaponAmmo = TotalAmmo;
    }
}
