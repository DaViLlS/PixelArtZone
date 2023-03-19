using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NeutralNPC : NPC
{
    [SerializeField] public NeutralNpcSO neutralNpcSO;
    public State followQuestState;
    public State idleState;

    public Action onObjectiveCompleted;

    private void Start()
    {
        if (neutralNpcSO.npcQuest != null)
        {
            neutralNpcSO.npcQuest._currQuestStatus = neutralNpcSO.npcQuest.questStatus;
            neutralNpcSO.npcQuest.npc = this;
        }
       
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
            
        }

    }

    public override void SetState(State state)
    {
        CurrentState = Instantiate(state);
        CurrentState.Npc = this;
        CurrentState.Init();
    }
}
