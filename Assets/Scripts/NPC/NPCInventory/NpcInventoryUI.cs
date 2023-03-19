using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcInventoryUI : MonoBehaviour
{
    [SerializeField] public GameObject itemUi;
    [SerializeField] private GameObject itemSlot;
    private List<ItemSO> _npcItems;
    private NPC _npc;
    private Inventory _inventory;
    private NPCInventory _npcInventory;
    private bool _slotsGenerated;

    private void Awake()
    {
        gameObject.SetActive(false);
        _slotsGenerated = false;
    }

    public void SetNpc(NPC npc)
    {
        _npc = npc;
    }

    public NPC GetNpc()
    {
        return _npc;
    }

    public void SetInventory(Inventory inventory, List<ItemSO> npcItems, NPCInventory npcInventory)
    {
        _npcItems = npcItems;
        _inventory = inventory;
        _npcInventory = npcInventory;
        GenerateSlots();
        AddItemsToSlots(npcItems);
    }

    public void CloseinventoryNpc()
    {
        RemoveInventory();
        gameObject.SetActive(false);
    }

    public void RemoveInventory()
    {
        bool isEmpty = true;
        int i = 0;
        if (_slotsGenerated)
        {
            _npcInventory.RemoveAllItems();
            foreach (ItemSlot slot in _inventory.itemList)
            {
                if (slot.item != null)
                {
                    isEmpty = false;
                    _npcInventory.SetItems(i, slot.item.GetComponent<ItemUI>().itemSO);
                    i++;
                }

                if (isEmpty)
                {
                    _npcInventory.RemoveAllItems();
                }

                Destroy(slot.gameObject);
            }
            _inventory.itemList.Clear();
        }
    }

    private void AddItemsToSlots(List<ItemSO> npcItems)
    {
        for (int i = 0; i < npcItems.Count; i++)
        {
            foreach (ItemSlot slot in _inventory.itemList)
            {
                if (slot.item == null)
                {
                    slot.AddItem(npcItems[i], this);
                    break;
                }
            }
        }
    }

    private void GenerateSlots()
    {
        _slotsGenerated = true;
        float startX = 30;
        float startY = -30;
        float offset = 60f;
        int x = 1;

        for (int i = 0; i < 56; i++)
        {
            GameObject tmpObj = Instantiate(itemSlot, Vector3.zero, Quaternion.identity);
            tmpObj.transform.SetParent(gameObject.transform);
            tmpObj.GetComponent<ItemSlot>().isNpcInventory = true;
            _inventory.itemList.Add(tmpObj.GetComponent<ItemSlot>());

            tmpObj.GetComponent<RectTransform>().anchoredPosition = new Vector2(startX, startY);
            if (x == 8)
            {
                startY -= offset;
                startX = 30;
                x = 1;
            }
            else
            {
                startX += offset;
                x++;
            }
        }
    }
}
