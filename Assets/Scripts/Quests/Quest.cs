using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Quest/New Quest")]

public class Quest : ScriptableObject
{
    [SerializeField] public string questName;
    [SerializeField] public string questDescription;
    [SerializeField] public Objective[] objectives;
    public PlayerQuests playerQuest;
    public NeutralNPC npc;
    public string questStatus;
    protected bool isFinished;
    public string _currQuestStatus;

    public void StartQuest()
    {
        _currQuestStatus = "В процессе";

        foreach (Objective objective in objectives)
        {
            objective.SetObjectivesQuest(this);
        }
    }

    public void CheckQuest()
    {
        bool isQuestCompleted = false;

        foreach (Objective objective in objectives)
        {
            if (objective.objectiveStatus == "Выполнено")
            {
                isQuestCompleted = true;
                playerQuest.questsObjectives.ChangeObjetctiveView(objective);
            }
            else
            {
                isQuestCompleted = false;
            }
        }

        if (isQuestCompleted == true)
        {
            CompleteQuest();
        }
    }

    public void CompleteQuest()
    {
        _currQuestStatus = "Выполнено";
        if (playerQuest.currentQuest == this)
            playerQuest.ChangeQuest();
    }
}
