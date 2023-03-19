using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Objectives/ArriveObjective")]
public class ArriveObjective : Objective
{
    private QuestTarget _targetQuest;

    public override void SetObjectivesQuest(Quest quest)
    {
        objectivesQuest = quest;
        objectiveStatus = "В процессе";
    }

    protected override void CheckObjective()
    {

    }

    protected override void CompleteObjective()
    {
        objectiveStatus = "Выполнено";
        _targetQuest.onObjectiveCompleted -= CompleteObjective;
        Destroy(_targetQuest.gameObject);
        objectivesQuest.CheckQuest();
    }

    public override void SetTarget(QuestTarget target)
    {
        _targetQuest = target;
        _targetQuest.onObjectiveCompleted += CompleteObjective;
    }
}
