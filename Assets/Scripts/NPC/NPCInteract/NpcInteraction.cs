using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NpcInteraction : MonoBehaviour
{
    [SerializeField] private GameObject dialogUi;
    [SerializeField] public NPCInventory npcInventory;
    [SerializeField] public NeutralNPC neuralNpc;
    [SerializeField] private Dialog[] npcDialog;
    public PlayerQuests _playerQuests;
    private DialogUi _dialogUi;

    private void Start()
    {
        _dialogUi = dialogUi.GetComponent<DialogUi>();
        dialogUi.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _playerQuests = player.GetComponent<PlayerQuests>();
            player.canTalk = true;
            player.npcInteraction = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.canTalk = false;
            player.npcInteraction = null;
            npcInventory.npcInventoryUi.RemoveInventory();
            npcInventory.npcInventoryUi.gameObject.SetActive(false);
        }
    }

    public void CloseInventory()
    {
        npcInventory.npcInventoryUi.RemoveInventory();
        npcInventory.npcInventoryUi.gameObject.SetActive(false);
        _playerQuests.GetComponent<Player>().isOpened = false;
    }

    public void OpenDialogMenu()
    {
        dialogUi.SetActive(true);
        Camera.main.orthographicSize = 3.3f;
        _playerQuests.GetComponent<Player>().isOpened = true;
        _dialogUi.SetDialogToUi(npcDialog, this);
    }

    public void CloseDialogMenu()
    {
        dialogUi.SetActive(false);
        Camera.main.orthographicSize = 6.6f;
        _playerQuests.GetComponent<Player>().isOpened = false;
    }
}
