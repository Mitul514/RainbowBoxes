using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] protected WeaponData weaponData;
    [SerializeField] protected PlayerManager playerManager;
    [SerializeField] protected UiManager uiManager;

    protected int TotalAmmo { get => weaponData.TotalWeaponAmmo; }
   
    private void Start()
    {
        weaponData.AmmoLeft = TotalAmmo;        
    }

    protected virtual void OnEnable()
    {
        playerManager.OnShootSignal += OnShootClicked;
        playerManager.OnWeapoReload += ReloadWeapon;
        uiManager.PrintWeaponData(weaponData);
        uiManager.PrintWeaponAmmo(weaponData);

    }

    protected void OnDisable()
    {
        playerManager.OnShootSignal -= OnShootClicked;
        playerManager.OnWeapoReload -= ReloadWeapon;
    }

    protected virtual void OnShootClicked()
    {
        weaponData.AmmoLeft -= 1;
    }

    protected void ReloadWeapon()
    {
        StartCoroutine(ReloadAfterDelay(weaponData.ReloadTime));
        uiManager.PrintWeaponAmmo(weaponData);
    }

    private IEnumerator ReloadAfterDelay(float delay)
    { 
        yield return new WaitForSeconds(delay);
        weaponData.AmmoLeft = TotalAmmo;
        uiManager.PrintWeaponAmmo(weaponData);
    }
}
