using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public GameObject item;
    public GameObject itemWorld;
    private InventoryUI _inventory;
    public bool isNpcInventory;

    private void Awake()
    {
        //_inventory = GameObject.Find("Inventory_UI").GetComponent<InventoryUI>();
    }

    public void AddItem(ItemSO itemSo, InventoryUI inventory)
    {
        _inventory = inventory;
        item = Instantiate(_inventory.itemUi, Vector2.zero, Quaternion.identity);
        item.transform.SetParent(transform);
        item.GetComponent<ItemUI>().activeSlot = GetComponent<ItemSlot>();
        item.GetComponent<ItemUI>().activeGunSlot = null;
        item.GetComponent<ItemUI>().itemSO = itemSo;
        item.GetComponent<ItemUI>().SetItemSo();
        item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }

    public void AddItem(ItemSO itemSo, NpcInventoryUI npcInventoryUI)
    {
        item = Instantiate(npcInventoryUI.itemUi, Vector2.zero, Quaternion.identity);
        item.transform.SetParent(transform);
        item.GetComponent<ItemUI>().activeSlot = GetComponent<ItemSlot>();
        item.GetComponent<ItemUI>().activeGunSlot = null;
        item.GetComponent<ItemUI>().itemSO = itemSo;
        item.GetComponent<ItemUI>().SetItemSo();
        item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }

    public void RemoveItem()
    {
        if (!isNpcInventory)
        {
            ItemWorld tmpObj = Instantiate(itemWorld, _inventory.GetPlayer().GetPosition(), Quaternion.identity).GetComponent<ItemWorld>();
            if (item.GetComponent<ItemUI>().itemSO.isStackable)
            {
                tmpObj.SetCurrentCount(item.GetComponent<ItemUI>().GetCurrentCount());
            }

            tmpObj.itemSo = item.GetComponent<ItemUI>().itemSO;
            Destroy(item);
            item = null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        ItemUI itemUI = eventData.pointerDrag.GetComponent<ItemUI>();
        if (item == null)
        {
            eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            item = eventData.pointerDrag.gameObject;
            if (itemUI.activeGunSlot != null)
            {
                itemUI.activeGunSlot.MoveToInventory();
                itemUI.activeGunSlot = null;
            }

            if (itemUI.activeSlot != null)
                itemUI.activeSlot.item = null;

            itemUI.activeSlot = GetComponent<ItemSlot>();
            itemUI.GetComponent<ItemDragDrop>().isInInventory = true;
        }
        else
        {
            eventData.pointerDrag.transform.SetParent(eventData.pointerDrag.GetComponent<ItemUI>().activeSlot.transform);
            eventData.pointerDrag.GetComponent<ItemDragDrop>().isInInventory = true;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }
    }
}
