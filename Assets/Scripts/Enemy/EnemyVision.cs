using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    private EnemyNPC _enemyNpc;

    private void Start()
    {
        _enemyNpc = GetComponentInParent<EnemyNPC>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            if (_enemyNpc.CurrentState is WalkState)
            {
                _enemyNpc.CurrentState.Stop();
                _enemyNpc.SetState(_enemyNpc.ChaseState);
                _enemyNpc.CurrentState.SetPlayer(player);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            if (_enemyNpc.CurrentState is ChaseState)
            {
                StartCoroutine(stopChasing());
            }
        }
    }

    IEnumerator stopChasing()
    {
        yield return new WaitForSeconds(2);
        _enemyNpc.CurrentState.Stop();
        _enemyNpc.SetState(_enemyNpc.WalkState);
    }
}
