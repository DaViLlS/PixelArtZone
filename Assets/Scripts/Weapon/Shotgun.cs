using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Shotgun : WeaponController
{
    private bool _canShoot;
    private int bulletAmount;
    private Player _player;
    private TextMeshProUGUI ammoText;
    private bool _canReload;

    private void OnEnable()
    {
        onReload += Reload;
        onShoot += Shoot;
    }
    private void OnDisable()
    {
        onReload -= Reload;
        onShoot -= Shoot;
    }

    private void Awake()
    {
        _canShoot = true;
        _canReload = true;
        bulletAmount = 2;
        _player = GetComponent<Player>();
        ammoText = GameObject.Find("AmmoText").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        ammoText.text = bulletAmount + "/" + weaponInfo.bulletsCapacity;
    }

    public override void SetAmmoText()
    {
        ammoText.text = bulletAmount + "/" + weaponInfo.bulletsCapacity;
    }

    protected override void Reload()
    {
        if (_canReload)
        {
            string weaponType = weaponInfo.weaponType;
            Inventory inventory = _player.GetInventory();

            foreach (ItemSlot slot in inventory.itemList)
            {
                if (slot.item != null && slot.item.GetComponent<ItemUI>().itemSO is BulletsSO bulletsSo && weaponInfo.bulletsCapacity != bulletAmount)
                {
                    if (bulletsSo.bulletType == "Shotgun")
                    {
                        int availableAmount = slot.item.GetComponent<ItemUI>().GetCurrentCount();
                        int amountToReload = weaponInfo.bulletsCapacity - bulletAmount;

                        if (availableAmount == amountToReload)
                        {
                            _player.GetComponent<PlayerWeapon>().GetComponent<AudioSource>().PlayOneShot(weaponInfo.reloadSound);
                            StartCoroutine(ReloadCoolDown(slot, availableAmount, amountToReload));
                        }
                        else if (availableAmount > amountToReload)
                        {
                            _player.GetComponent<PlayerWeapon>().GetComponent<AudioSource>().PlayOneShot(weaponInfo.reloadSound);
                            StartCoroutine(ReloadCoolDown(slot, weaponInfo.bulletsCapacity, amountToReload));
                            //bulletAmount = weaponInfo.bulletsCapacity;
                            //ammoText.text = bulletAmount + "/" + weaponInfo.bulletsCapacity;
                            //slot.item.GetComponent<ItemUI>().RemoveCurrentCount(amountToReload);
                        }
                        else if (availableAmount < amountToReload)
                        {
                            StartCoroutine(halfReload(slot, availableAmount));
                            //bulletAmount = availableAmount;
                            //ammoText.text = bulletAmount + "/" + weaponInfo.bulletsCapacity;
                            //slot.item.GetComponent<ItemUI>().RemoveCurrentCount(availableAmount);
                        }
                    }
                }
            }
        }
    }

    IEnumerator ReloadCoolDown(ItemSlot slot, int availableAmount, int amountToReload)
    {
        _canReload = false;
        yield return new WaitForSeconds(1.5f);
        bulletAmount = availableAmount;
        ammoText.text = bulletAmount + "/" + weaponInfo.bulletsCapacity;
        slot.item.GetComponent<ItemUI>().RemoveCurrentCount(amountToReload);
        _canReload = true;
    }

    IEnumerator halfReload(ItemSlot slot, int availableAmount)
    {
        _player.GetComponent<PlayerWeapon>().GetComponent<AudioSource>().PlayOneShot(weaponInfo.reloadSound);
        yield return new WaitForSeconds(0.5f);
        bulletAmount = availableAmount;
        ammoText.text = bulletAmount + "/" + weaponInfo.bulletsCapacity;
        slot.item.GetComponent<ItemUI>().RemoveCurrentCount(availableAmount);
        _player.GetComponent<PlayerWeapon>().GetComponent<AudioSource>().Stop();
    }

    protected override void Shoot()
    {
        if (_canShoot && bulletAmount > 0)
        {
            Bullet bulletFirst = Instantiate(bulletPref, transform.position + new Vector3(0, 1, 0), Quaternion.identity).GetComponent<Bullet>();
            Bullet bulletSecond = Instantiate(bulletPref, transform.position + new Vector3(0, 1, 0), Quaternion.identity).GetComponent<Bullet>();
            Bullet bulletThird = Instantiate(bulletPref, transform.position + new Vector3(0, 1, 0), Quaternion.identity).GetComponent<Bullet>();
            Bullet bulletFourth = Instantiate(bulletPref, transform.position + new Vector3(0, 1, 0), Quaternion.identity).GetComponent<Bullet>();
            Bullet bulletFifth = Instantiate(bulletPref, transform.position + new Vector3(0, 1, 0), Quaternion.identity).GetComponent<Bullet>();
            Bullet bulletSixth = Instantiate(bulletPref, transform.position + new Vector3(0, 1, 0), Quaternion.identity).GetComponent<Bullet>();
            Bullet bulletSeventh = Instantiate(bulletPref, transform.position + new Vector3(0, 1, 0), Quaternion.identity).GetComponent<Bullet>();
            Bullet bulletEighth = Instantiate(bulletPref, transform.position + new Vector3(0, 1, 0), Quaternion.identity).GetComponent<Bullet>();

            bulletFirst.SetDamage(Int32.Parse(weaponInfo.damage));
            bulletSecond.SetDamage(Int32.Parse(weaponInfo.damage));
            bulletThird.SetDamage(Int32.Parse(weaponInfo.damage));
            bulletFourth.SetDamage(Int32.Parse(weaponInfo.damage));

            bulletAmount -= 1;
            ammoText.text = bulletAmount + "/" + weaponInfo.bulletsCapacity;
            _player._anim.SetBool("isShoot", true);
            _player.GetComponent<PlayerWeapon>().playerShootLight.StartShootLight();
            _player.GetComponent<PlayerWeapon>().GetComponent<AudioSource>().Play();
            StartCoroutine(ShootCooldown());
        }
        else if (bulletAmount <= 0)
        {
            Reload();
        }
    }

    IEnumerator ShootCooldown()
    {
        _canShoot = false;
        yield return new WaitForSeconds(0.5f);
        _player._anim.SetBool("isShoot", false);
        _canShoot = true;
    }
}
