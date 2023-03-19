using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Objectives/FollowObjective")]
public class FollowObjective : Objective
{
    public override void SetObjectivesQuest(Quest quest)
    {
        objectivesQuest = quest;
        objectiveStatus = "� ��������";
        objectivesQuest.npc.onObjectiveCompleted += CheckObjective;
    }

    protected override void CheckObjective()
    {
        CompleteObjective();
    }

    protected override void CompleteObjective()
    {
        objectiveStatus = "���������";
        objectivesQuest.npc.onObjectiveCompleted -= CheckObjective;
        objectivesQuest.CheckQuest();
    }
}
