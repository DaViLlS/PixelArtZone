using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Player _player;
    private PlayerHealth _playerHealth;
    private Image _healthBar;

    private void Start()
    {
        _playerHealth = _player.GetComponent<PlayerHealth>();
        _healthBar = GetComponent<Image>();
    }

    public void UpdateBar()
    {
        _healthBar.fillAmount = _playerHealth.GetHealth() / _playerHealth.maxHealth;
    }

    public void SetPlayer(Player player)
    {
        _player = player;
    }
}
