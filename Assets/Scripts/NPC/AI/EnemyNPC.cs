using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyNPC : NPC
{
    public State WalkState;
    public State ChaseState;

    private void Start()
    {
        SetState(StartState);
    }

    private void Update()
    {
        if (!CurrentState.IsFinished)
        {
            CurrentState.Run();
        }
        else
        {
            if (CurrentState is ChaseState chase && CurrentState.IsFinished)
            {
                SetState(WalkState);
            }
        }
        
    }

    public override void SetState(State state)
    {
        CurrentState = Instantiate(state);
        CurrentState.Npc = this;
        CurrentState.Init();
    }
}
