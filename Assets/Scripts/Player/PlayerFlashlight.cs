using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlashlight : MonoBehaviour
{
    private Light _playerFlashlight;
    private GameObject _flashlightGameObjet;

    private void Awake()
    {
        _playerFlashlight = GetComponentInChildren<Light>();
        _flashlightGameObjet = _playerFlashlight.gameObject;
        _flashlightGameObjet.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (!_flashlightGameObjet.activeSelf)
                _flashlightGameObjet.SetActive(true);
            else
                _flashlightGameObjet.SetActive(false);
        }
    }
}
