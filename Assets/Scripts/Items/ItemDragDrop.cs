using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform canvasTransform;
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    public bool isInInventory;
    public bool isInGunSlot;
    public bool isInNpcInventory;
    private ItemUI itemUi;

    private void Awake()
    {
        isInInventory = true;
        isInGunSlot = false;
        canvasTransform = GameObject.Find("MainCanvas").transform;
        canvas = canvasTransform.GetComponent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        itemUi = GetComponent<ItemUI>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        transform.SetParent(canvasTransform);
        isInInventory = false;
        isInGunSlot = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isInInventory && !isInGunSlot)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
        }
        else if (!isInGunSlot && !isInInventory)
        {
            if (itemUi.activeGunSlot == null && itemUi.activeSlot != null)
            {
                GameObject tmp = GameObject.Find("Inventory_UI");
                if (tmp != null)
                {
                    tmp.GetComponent<InventoryUI>().GetInventory().RemoveItem(itemUi);
                }
                else
                {
                    canvasGroup.alpha = 1f;
                    canvasGroup.blocksRaycasts = true;
                    transform.SetParent(GetComponent<ItemUI>().activeSlot.transform);
                    isInInventory = true;
                    GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                }
            }
            else if (itemUi.activeSlot == null && itemUi.activeGunSlot != null)
            {
                itemUi.activeGunSlot.RemoveItem();
            }
        }
        else if (isInGunSlot && !isInInventory)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
            transform.SetParent(GetComponent<ItemUI>().activeGunSlot.transform);
            isInGunSlot = true;
            GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }
    }
}
