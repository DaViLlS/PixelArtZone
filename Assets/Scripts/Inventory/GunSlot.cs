using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GunSlot : MonoBehaviour, IDropHandler
{
    public GameObject item;
    public GameObject itemWorld;
    [SerializeField] private InventoryUI _inventory;
    private Player _player;
    public bool isActiveGunSlot;

    public void SetPlayer(Player player)
    {
        _player = player;
    }

    public void RemoveItem()
    {
        ItemWorld tmpObj = Instantiate(itemWorld, _inventory.GetPlayer().GetPosition(), Quaternion.identity).GetComponent<ItemWorld>();

        tmpObj.itemSo = item.GetComponent<ItemUI>().itemSO;
        Destroy(item);
        item = null;

        if (isActiveGunSlot)
        {
            _player.GetComponent<PlayerWeapon>().RemoveWeapon();
            isActiveGunSlot = false;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        ItemUI itemUi = eventData.pointerDrag.GetComponent<ItemUI>();
        if (item == null && itemUi.itemSO is WeaponSO weaponSo)
        {
            if (gameObject.name == "MainGun" && (weaponSo.weaponType == "Auto" || weaponSo.weaponType == "Shotgun"))
            {
                eventData.pointerDrag.transform.SetParent(transform);
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                item = eventData.pointerDrag.gameObject;
                eventData.pointerDrag.GetComponent<ItemUI>().activeSlot.item = null;
                eventData.pointerDrag.GetComponent<ItemUI>().activeGunSlot = GetComponent<GunSlot>();
                eventData.pointerDrag.GetComponent<ItemUI>().activeSlot = null;
                eventData.pointerDrag.GetComponent<ItemDragDrop>().isInInventory = false;
                eventData.pointerDrag.GetComponent<ItemDragDrop>().isInGunSlot = true;
                _player.playerWeapon.ChangeWeapon(weaponSo);
            }
            else if (gameObject.name == "Pistol" && weaponSo.weaponType == "Pistol")
            {
                eventData.pointerDrag.transform.SetParent(transform);
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                item = eventData.pointerDrag.gameObject;
                eventData.pointerDrag.GetComponent<ItemUI>().activeSlot.item = null;
                eventData.pointerDrag.GetComponent<ItemUI>().activeGunSlot = GetComponent<GunSlot>();
                eventData.pointerDrag.GetComponent<ItemUI>().activeSlot = null;
                eventData.pointerDrag.GetComponent<ItemDragDrop>().isInInventory = false;
                eventData.pointerDrag.GetComponent<ItemDragDrop>().isInGunSlot = true;
                _player.playerWeapon.ChangeWeapon(weaponSo);
            }
        }
        else
        {
            if (eventData.pointerDrag.GetComponent<ItemUI>().activeGunSlot != null)
                eventData.pointerDrag.transform.SetParent(eventData.pointerDrag.GetComponent<ItemUI>().activeGunSlot.transform);
            else if (eventData.pointerDrag.GetComponent<ItemUI>().activeSlot != null)
                eventData.pointerDrag.transform.SetParent(eventData.pointerDrag.GetComponent<ItemUI>().activeSlot.transform);

            eventData.pointerDrag.GetComponent<ItemDragDrop>().isInInventory = true;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }
    }

    public void MoveToInventory()
    {
        item = null;
        if (isActiveGunSlot)
        {
            _player.GetComponent<PlayerWeapon>().RemoveWeapon();
            isActiveGunSlot = false;
        }
    }
}
