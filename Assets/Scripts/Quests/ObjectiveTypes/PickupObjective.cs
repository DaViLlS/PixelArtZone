using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Objectives/PickupObjective")]
public class PickupObjective : Objective
{
    private Inventory _inventory;
    [SerializeField] private ItemSO questItem;

    public override void SetObjectivesQuest(Quest quest)
    {
        objectivesQuest = quest;
        objectiveStatus = "В процессе";
        _inventory = objectivesQuest.playerQuest.GetComponent<Player>().GetInventory();
        _inventory.onObjectiveCompleted += CheckObjective;
    }

    protected override void CheckObjective()
    {
        foreach (ItemSlot slot in _inventory.itemList)
        {
            if (slot.item != null)
            {
                if (slot.item.GetComponent<ItemUI>().itemSO.name == questItem.name)
                {
                    CompleteObjective();
                }
            }
        }
    }

    protected override void CompleteObjective()
    {
        objectiveStatus = "Выполнено";
        objectivesQuest.CheckQuest();
    }
}
