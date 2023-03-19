using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInventory : MonoBehaviour
{
    [SerializeField] public NpcInventoryUI npcInventoryUi;
    [SerializeField] List<ItemSO> npcitems;
    private List<ItemSO> npcItemsInGame;
    Inventory _inventory;

    private void Awake()
    {
        _inventory = new Inventory();
        npcItemsInGame = npcitems;
    }

    private void Start()
    {
    }

    public void OpenInventory()
    {
        npcInventoryUi.gameObject.SetActive(true);
        npcInventoryUi.SetInventory(_inventory, npcItemsInGame, this);
    }

   public void SetItems(int i, ItemSO item)
    {
        npcItemsInGame.Add(item);
    }

    public void RemoveAllItems()
    {
        for (int i = 0; i < npcItemsInGame.Count; i++)
        {
            npcItemsInGame.Clear();
        }
    }
}
