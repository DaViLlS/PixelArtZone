using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boar : Enemy
{
    private EnemyNPC _enemyAI;
    private EnemySpawner enemySpawner;
    private int _health;

    private void Start()
    {
        enemySpawner = GetComponentInParent<EnemySpawner>();
        transform.position = enemySpawner.transform.position;
        _health = enemyHealth;
        _enemyAI = GetComponent<EnemyNPC>();
    }

    public override void ReturnHealth()
    {
        _health = enemyHealth;
    }

    public override void ApplyDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            _enemyAI.SetState(_enemyAI.WalkState);
            enemySpawner.RemoveEnemy(gameObject.gameObject);
        }
    }

    public override int Hit()
    {
        return enemyDamage;
    }
}
