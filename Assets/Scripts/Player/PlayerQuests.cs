using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuests : MonoBehaviour
{
    [SerializeField] private ActiveQuestUI activeQuestUi;
    [SerializeField] private Quest[] questsToAdd;
    [SerializeField] public ActiveQuestsObjectives questsObjectives;
    [SerializeField] private GameObject objcetivesPanel;

    public Quest currentQuest;
    public List<Quest> questList;

    private void Start()
    {
        if (questsToAdd != null)
        {
            SetQuest(questsToAdd[0]);
        }
    }

    public void SetQuest(Quest quest)
    {
        currentQuest = quest;
        questList.Add(quest);
        currentQuest.playerQuest = this;
        currentQuest.StartQuest();
        if (currentQuest != null)
        {
            activeQuestUi.SetActiveQuestUi(currentQuest.questName, currentQuest.questDescription);
            questsObjectives.SetObjectives(currentQuest.objectives);
            objcetivesPanel.SetActive(true);
        }
    }

    public void ChangeQuest()
    {
        bool isEmpty = true;
        foreach (Quest quest in questList)
        {
            if (quest._currQuestStatus == "В процессе")
            {
                isEmpty = false;
                currentQuest = quest;
                activeQuestUi.SetActiveQuestUi(currentQuest.questName, currentQuest.questDescription);
                questsObjectives.SetObjectives(currentQuest.objectives);
                objcetivesPanel.SetActive(true);
            }
        }

        if (isEmpty == true)
        {
            activeQuestUi.SetActiveQuestUi("", "Заданий нет, можно и на перекур");
            objcetivesPanel.SetActive(false);
        }
    }
}
