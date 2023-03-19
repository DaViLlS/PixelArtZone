using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public float maxHealth;
    private float _health;

    private void Awake()
    {
        _health = maxHealth;
    }

    public void GetDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            GetComponent<Player>().Die();
        }
    }

    public void SetHealth(float health)
    {
        _health = health;
    }

    public float GetHealth()
    {
        return _health;
    }
}
