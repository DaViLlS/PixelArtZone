using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] public GameObject itemUi;
    [SerializeField] private GameObject itemSlot;
    private Player _player;
    private Inventory _inventory;

    public void SetPlayer(Player player)
    {
        _player = player;
    }

    public Player GetPlayer()
    {
        return _player;
    }

    public void SetInventory(Inventory inventory)
    {
        _inventory = inventory;
        GenerateSlots();
        gameObject.SetActive(false);
    }

    public Inventory GetInventory()
    {
        return _inventory;
    }

    private void GenerateSlots()
    {
        float startX = 30;
        float startY = -30;
        float offset = 60f;
        int x = 1;

        for (int i = 0; i < 56; i++)
        {
            GameObject tmpObj = Instantiate(itemSlot, Vector3.zero, Quaternion.identity);
            tmpObj.transform.SetParent(gameObject.transform);
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
