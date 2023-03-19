using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Objective : ScriptableObject
{
    [SerializeField] public string objectiveName;
    protected Quest objectivesQuest;
    [HideInInspector] public string objectiveStatus;

    protected abstract void CheckObjective();

    protected abstract void CompleteObjective();

    public abstract void SetObjectivesQuest(Quest quest);

    public virtual void SetTarget(QuestTarget target)
    {
        //_targetQuest = target;
        //_targetQuest.onObjectiveCompleted += CompleteQuest;
    }
}
