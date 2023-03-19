using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiationStatus : Status
{
    private PlayerStatus _playerStatus;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerStatus playerStatus))
        {
            _playerStatus = playerStatus;
            _playerStatus.inZone = true;
            StartCoroutine(GiveStatus());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerStatus playerStatus))
        {
            _playerStatus.inZone = false;
            _playerStatus.OnZoneExit();
        }
    }

    public override int GetStatus()
    {
        return zoneStatusDmg;
    }

    public override string GetZoneType()
    {
        return zoneType;
    }

    IEnumerator GiveStatus()
    {
        if (_playerStatus != null)
        {
            while (_playerStatus.inZone)
            {
                _playerStatus.radiationDmg += zoneStatusDmg;
                _playerStatus.GetStatus();
                yield return new WaitForSeconds(3);
            }
        }
    }
}
