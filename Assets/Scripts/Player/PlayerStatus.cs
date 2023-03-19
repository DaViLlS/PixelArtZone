using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private AudioSource radiationAudio;
    [SerializeField] private Image radiationUI;
    [SerializeField] private Image bioUI;
    private Player _player;
    private PlayerHealth _playerHealth;
    public bool inZone;
    public int radiationDmg;
    public int bioDmg;

    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        inZone = false;
        _player = GetComponent<Player>();
    }

    public void GetStatus()
    {
        if (radiationDmg > 0)
        {
            radiationUI.gameObject.SetActive(true);
            StartCoroutine(HealthRemover());
            radiationAudio.Play();
        }
        else if (radiationDmg <= 0)
        {
            radiationUI.gameObject.SetActive(false);
            radiationAudio.Stop();
        }
        if (bioDmg > 0)
        {
            bioUI.gameObject.SetActive(true);
            StartCoroutine(HealthRemover());
        }
        else if (bioDmg <= 0)
        {
            bioUI.gameObject.SetActive(false);
        }
    }

    private void RemoveStatus()
    {
        if (radiationDmg > 0)
            radiationDmg -= 2;
        if (bioDmg > 0)
            bioDmg -= 2;
    }

    private void RemoveHealth()
    {
        if (radiationDmg > 0)
            _playerHealth.GetDamage(radiationDmg);
        if (bioDmg > 0)
            _playerHealth.GetDamage(bioDmg);
        _player.healthBar.UpdateBar();
    }

    public void OnZoneExit()
    {
        StartCoroutine(StatusRemover());
    }

    IEnumerator StatusRemover()
    {
        while ((radiationDmg > 0 || bioDmg > 0) && inZone == false)
        {
            yield return new WaitForSeconds(3);
            RemoveStatus();
            GetStatus();
        }
    }

    IEnumerator HealthRemover()
    {
        while (radiationDmg > 0 || bioDmg > 0)
        {
            yield return new WaitForSeconds(5);
            RemoveHealth();
        }
    }

    public void ResetStatus()
    {
        inZone = false;
        radiationUI.gameObject.SetActive(false);
        bioUI.gameObject.SetActive(false);
        radiationAudio.Stop();
        radiationDmg = 0;
        bioDmg = 0;
    }
}
