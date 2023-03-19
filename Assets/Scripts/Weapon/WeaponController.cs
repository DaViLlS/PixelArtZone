using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class WeaponController : MonoBehaviour
{
    public WeaponSO weaponInfo;
    public GameObject bulletPref;

    public Action onShoot;
    public Action onReload;

    protected abstract void Shoot();
    protected abstract void Reload();
    public abstract void SetAmmoText();
}
