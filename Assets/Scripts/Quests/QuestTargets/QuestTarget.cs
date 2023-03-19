using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuestTarget : MonoBehaviour
{
    [SerializeField] private Objective objective;

    public Action onObjectiveCompleted;

    private void Start()
    {
        objective.SetTarget(this);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            onObjectiveCompleted?.Invoke();
        }
    }
}
