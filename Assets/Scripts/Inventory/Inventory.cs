using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory
{
    public List<ItemSlot> itemList;
    private InventoryUI _inventoryUi;

    public Action onObjectiveCompleted;

    public Inventory(InventoryUI inventryUi)
    {
        itemList = new List<ItemSlot>();
        _inventoryUi = inventryUi;
    }

    public Inventory()
    {
        itemList = new List<ItemSlot>();
    }

    public void AddItem(ItemWorld itemWorld)
    {
        if (itemWorld.itemSo.isStackable)
        {
            bool itemAlreadyInInventory = false;

            foreach (ItemSlot slot in itemList)
            {
                if (slot.item != null && itemWorld.itemSo.name == slot.item.GetComponent<ItemUI>().itemSO.name)
                {
                    slot.item.GetComponent<ItemUI>().SetCurrentCount(itemWorld.GetCurrentCount());
                    itemAlreadyInInventory = true;
                    break;
                }
            }

            if (!itemAlreadyInInventory)
            {
                foreach (ItemSlot slot in itemList)
                {
                    if (slot.item == null)
                    {
                        slot.AddItem(itemWorld.itemSo, _inventoryUi);
                        slot.item.GetComponent<ItemUI>().SetCurrentCount(itemWorld.GetCurrentCount());
                        break;
                    }
                }
            }
        }
        else
        {
            foreach (ItemSlot slot in itemList)
            {
                if (slot.item == null)
                {
                    slot.AddItem(itemWorld.itemSo, _inventoryUi);
                    onObjectiveCompleted?.Invoke();
                    break;
                }
            }
        }
    }

    public void RemoveItem(ItemUI item)
    {
        if (item.itemSO.isStackable)
        {
            foreach (ItemSlot slot in itemList)
            {
                if (item.gameObject == slot.item)
                {
                    //slot.item.GetComponent<ItemUI>().RemoveCurrentCount(1);
                    //if (slot.item.GetComponent<ItemUI>().GetCurrentCount() <= 0)
                    //{
                        slot.RemoveItem();
                    //}
                }
            }
        }
        else
        {
            item.activeSlot.RemoveItem();
        }
    }

    public List<ItemSlot> GetItemList()
    {
        return itemList;
    }
}
