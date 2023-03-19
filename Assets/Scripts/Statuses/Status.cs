using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Status : MonoBehaviour
{
    [SerializeField] public string zoneType;
    [SerializeField] public int zoneStatusDmg;
    protected PlayerHealth _playerHealth;

    public abstract int GetStatus();
    public abstract string GetZoneType();
}
