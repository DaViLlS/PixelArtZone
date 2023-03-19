using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected string enemyName;
    [SerializeField] protected int enemyHealth;
    [SerializeField] protected int enemyDamage;
    [SerializeField] public float speed;

    public abstract void ApplyDamage(int damage);
    public abstract void ReturnHealth();
    public abstract int Hit();
}
