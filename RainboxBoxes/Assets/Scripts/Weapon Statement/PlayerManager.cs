using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] protected WeaponManager pWeaponObj, sWeaponObj;
    public Action OnShootSignal, OnWeapoReload;
    private bool isPrimaryActive;
    private Coroutine coroutine;

    private void OnEnable()
    {
        if (coroutine == null)
        {
            coroutine = StartCoroutine(WeaponUpdate());
        }
        pWeaponObj.gameObject.SetActive(false);
        sWeaponObj.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        StopCoroutine(coroutine);
    }

    private IEnumerator WeaponUpdate()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
                OnShootSignal?.Invoke();

            if (Input.mouseScrollDelta.y < 0 || Input.mouseScrollDelta.y > 0)
                OnWeaponSwitch();

            if (Input.GetKeyDown(KeyCode.R))
                OnWeapoReload?.Invoke();

            yield return null;
        }
    }

    private void OnWeaponSwitch()
    {
        isPrimaryActive = !isPrimaryActive;

        if (isPrimaryActive)
        {
            pWeaponObj.gameObject.SetActive(true);
            sWeaponObj.gameObject.SetActive(false);
        }
        else
        {
            pWeaponObj.gameObject.SetActive(false);
            sWeaponObj.gameObject.SetActive(true);
        }
    }
}
