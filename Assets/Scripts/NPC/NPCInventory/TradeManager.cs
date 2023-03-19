using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TradeManager : MonoBehaviour
{
    private Player _player;
    private NpcMoney _npc;
    private List<ItemUI> itemsToTrade;

    public Action<ItemUI> onTradeItem;
    public Action onTradeExit;

    private void Awake()
    {
        itemsToTrade = new List<ItemUI>();
    }

    public void StartTrade()
    {
        onTradeItem += AddItem;
        onTradeExit += ResetItems;
    }

    private void ConfirmTrade()
    {
        foreach (ItemUI item in itemsToTrade)
        {
            if (item.isBuy)
            {
                if (item.itemSO.itemCost <= _player.GetMoney())
                {
                    _player.SetMoney(-item.itemSO.itemCost);
                }
                else
                {
                    Debug.Log("Недостаточно средств");
                }
            }
            else if (item.isSale)
            {
                if (item.itemSO.itemCost <= _npc.GetMoney())
                {
                    _npc.SetMoney(-item.itemSO.itemCost);
                }
                else
                {
                    Debug.Log("У нпс недостаточно средств");
                }
            }
        }
    }

    private void AddItem(ItemUI item)
    {
        itemsToTrade.Add(item);
    }

    private void RemoveItem(ItemUI item)
    {
        itemsToTrade.Remove(item);
    }

    private void ResetItems()
    {
        itemsToTrade.Clear();
    }
}
