using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBullets", menuName = "Items/Bullets", order = 51)]
public class BulletsSO : ItemSO
{
    [SerializeField] public string bulletType;
}
