using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Items/Weapon", order = 51)]
public class WeaponSO : ItemSO
{
    [SerializeField] public string weaponType;
    [SerializeField] public string damage;
    [SerializeField] public int bulletsCapacity;
    [SerializeField] public GameObject bulletPrefab;
    [SerializeField] public AudioClip shootSound;
    [SerializeField] public AudioClip reloadSound;
}