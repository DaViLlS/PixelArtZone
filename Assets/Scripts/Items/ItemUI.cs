using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public ItemSO itemSO;
    public ItemSlot activeSlot;
    public GunSlot activeGunSlot;
    public int amount;
    private int curentAmount;
    private Text counText;
    public bool isBuy;
    public bool isSale;

    private void Awake()
    {
        counText = GetComponentInChildren<Text>();
        SetCurrentCount(amount);
    }

    public void SetCurrentCount(int cnt)
    {
        curentAmount += cnt;
        counText.text = "" + curentAmount;
    }

    public void RemoveCurrentCount(int cnt)
    {
        curentAmount -= cnt;
        if (curentAmount <= 0)
        {
            activeSlot.item = null;
            Destroy(gameObject);
        }
        else
        {
            counText.text = "" + curentAmount;
        }
    }

    public int GetCurrentCount()
    {
        return curentAmount;
    }

    public void SetItemSo()
    {
        GetComponent<Image>().sprite = itemSO.iconUI;
        if (!itemSO.isStackable)
        {
            counText.gameObject.SetActive(false);
        }
    }
}
