using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] public InventoryUI inventoryUI;
    [SerializeField] public HealthBar healthBar;
    [SerializeField] public TextMeshProUGUI moneyText;

    [SerializeField] public GunSlot _pistolGunSlot;
    [SerializeField] public GunSlot _mainGunSlot;

    public Animator _anim;
    public PlayerWeapon playerWeapon;
    private Inventory _inventory;
    private ItemWorld itemWorld;
    private bool _isCanPickUp;
    private bool _canOpen;
    private bool _isPlayerWithGun;
    public bool canTalk;
    public bool isOpened;
    public NpcInteraction npcInteraction;
    private DoorInteract _interactableDoor;
    private PlayerStatus _playerStatus;
    private int _playerMoney;

    private void Awake()
    {
        _inventory = new Inventory(inventoryUI);
        inventoryUI.SetPlayer(this);
        inventoryUI.SetInventory(_inventory);

        _mainGunSlot.SetPlayer(this);
        _pistolGunSlot.SetPlayer(this);

        healthBar.SetPlayer(this);

        isOpened = false;

        playerWeapon = GetComponent<PlayerWeapon>();

        _anim = GetComponent<Animator>();
        _isPlayerWithGun = false;

        _playerStatus = GetComponent<PlayerStatus>();

        _playerMoney = 0;
        moneyText.text = _playerMoney.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (inventoryUI.gameObject.activeSelf == true)
            {
                inventoryUI.gameObject.SetActive(false);
            }
            else
            {
                inventoryUI.gameObject.SetActive(true);
            }
        }

        if (_isCanPickUp)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _inventory.AddItem(itemWorld);
                Destroy(itemWorld.gameObject);
                itemWorld = null;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (_mainGunSlot.item != null && _mainGunSlot.item.GetComponent<ItemUI>().itemSO is WeaponSO weaponSO)
            {
                playerWeapon.ChangeWeapon(weaponSO);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (_pistolGunSlot.item != null && _pistolGunSlot.item.GetComponent<ItemUI>().itemSO is WeaponSO weaponSO)
            {
                playerWeapon.ChangeWeapon(weaponSO);
            }
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            playerWeapon.RemoveWeapon();
        }

        if (canTalk)
        {
            if (Input.GetKeyDown(KeyCode.F) && !isOpened)
            {
                isOpened = true;
                npcInteraction.OpenDialogMenu();
            }
            else if (Input.GetKeyDown(KeyCode.F) && isOpened)
            {
                isOpened = false;
                npcInteraction.CloseDialogMenu();
            }
        }

        if (_canOpen)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                _interactableDoor.InteractWithDoor();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ItemWorld item))
        {
            _isCanPickUp = true;
            itemWorld = item;
        }

        if (collision.TryGetComponent(out DoorInteract door))
        {
            Debug.Log("Открывайте! никогда не открывают...");
            SetCanOpen(door);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isCanPickUp = false;
        itemWorld = null;
        RemoveCanOpen();
    }

    public int GetMoney()
    {
        return _playerMoney;
    }

    public void SetMoney(int moneyToSet)
    {
        _playerMoney += moneyToSet;
        moneyText.text = _playerMoney.ToString();
    }

    public void GetDamage(int damage)
    {
        GetComponent<PlayerHealth>().GetDamage(damage);
        healthBar.UpdateBar();
    }

    public void Die()
    {
        Debug.Log("Я умер");
        _playerStatus.ResetStatus();
        EnemyNPC[] enemies = GameObject.FindObjectsOfType<EnemyNPC>();
        foreach (EnemyNPC enemy in enemies)
            enemy.SetState(enemy.WalkState);
        Revive();
    }

    public void Revive()
    {
        GetComponent<PlayerHealth>().SetHealth(GetComponent<PlayerHealth>().maxHealth);
        transform.position = new Vector2(0f, 0f);
    }

    public Inventory GetInventory()
    {
        return _inventory;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public bool CheckGun()
    {
        return _isPlayerWithGun;
    }

    public void SetGun()
    {
        _isPlayerWithGun = true;
    }

    public void RemoveGun()
    {
        _isPlayerWithGun = false;
    }

    public void SetCanOpen(DoorInteract door)
    {
        _canOpen = true;
        _interactableDoor = door;
    }

    public void RemoveCanOpen()
    {
        _canOpen = false;
        _interactableDoor = null;
    }

    public bool GetCanOpen()
    {
        return _canOpen;
    }
}
