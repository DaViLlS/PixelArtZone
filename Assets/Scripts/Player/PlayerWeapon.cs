using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerWeapon : MonoBehaviour
{
    public Animator _anim;
    private WeaponController weapon;
    private Player _player;
    public PlayerShootLight playerShootLight;
    public AudioSource weaponAudio;
    private InventoryUI _inventoryUI;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _anim = GetComponent<Animator>();
        weaponAudio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        playerShootLight = GetComponentInChildren<PlayerShootLight>();
        playerShootLight.gameObject.SetActive(false);
        _inventoryUI = _player.inventoryUI;
    }

    private void Update()
    {
        if (!_inventoryUI.gameObject.activeSelf && !_player.isOpened)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && _player.CheckGun() == true)
            {
                weapon.onShoot?.Invoke();
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && _player.CheckGun())
        {
            weapon.onReload?.Invoke();
        }
    }

    public void ChangeWeapon(WeaponSO weaponSo)
    {
        switch (weaponSo.weaponType)
        {
            case ("Pistol"):
                _anim.SetBool("isPistol", true);
                _anim.SetBool("isMainGun", false);
                _player._pistolGunSlot.isActiveGunSlot = true;
                _player._mainGunSlot.isActiveGunSlot = false;
                if (TryGetComponent(out Pistol pistol))
                {
                    weapon = pistol;
                }
                else
                {
                    weapon = gameObject.AddComponent(typeof(Pistol)) as Pistol;
                }
                weapon.bulletPref = weaponSo.bulletPrefab;
                weapon.weaponInfo = weaponSo;
                weaponAudio.clip = weaponSo.shootSound;
                weapon.SetAmmoText();
                _player.SetGun();
                break;
            case ("Shotgun"):
                _anim.SetBool("isMainGun", true);
                _anim.SetBool("isPistol", false);
                _player._pistolGunSlot.isActiveGunSlot = false;
                _player._mainGunSlot.isActiveGunSlot = true;
                if (TryGetComponent(out Shotgun shotgun))
                {
                    weapon = shotgun;
                }
                else
                {
                    weapon = gameObject.AddComponent(typeof(Shotgun)) as Shotgun;
                }
                weapon.bulletPref = weaponSo.bulletPrefab;
                weapon.weaponInfo = weaponSo;
                weaponAudio.clip = weaponSo.shootSound;
                weapon.SetAmmoText();
                _player.SetGun();
                break;
        }
    }

    public void RemoveWeapon()
    {
        _anim.SetBool("isMainGun", false);
        _anim.SetBool("isPistol", false);
        weapon = null;
        _player.RemoveGun();
    }
}
