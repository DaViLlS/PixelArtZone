using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI npcName;
    [SerializeField] private TextMeshProUGUI npcText;
    [SerializeField] private Transform answersLayout;
    [SerializeField] private GameObject answerPref;
    private List<GameObject> _answerObjects;
    private Dialog[] _dialogs;
    private int _dialogStatus;
    private NpcInteraction _npcInteraction;
    private NeutralNPC _neutralNPC;

    private void Awake()
    {
        _answerObjects = new List<GameObject>();
    }

    public void SetDialogToUi(Dialog[] dialogs, NpcInteraction npcInteraction)
    {
        _dialogStatus = 0;
        _dialogs = dialogs;
        _npcInteraction = npcInteraction;
        _neutralNPC = _npcInteraction.neuralNpc;
        StartDialog();
    }

    public void StartDialog()
    {
        npcName.text = _npcInteraction.neuralNpc.neutralNpcSO.neutralName;
        npcText.text = _dialogs[_dialogStatus].npcText;

        foreach (GameObject answer in _answerObjects)
        {
            Destroy(answer.gameObject);
        }

        _answerObjects.Clear();

        foreach (Answer answer in _dialogs[_dialogStatus].playerAnswers)
        {
            if (_neutralNPC.neutralNpcSO.npcQuest._currQuestStatus != "ֲûהאם")
            {
                GameObject answerTemp = Instantiate(answerPref, Vector2.zero, Quaternion.identity);
                Button tempButton = answerTemp.GetComponent<Button>();
                tempButton.onClick.AddListener(() => ChangeDialog(answer));

                TextMeshProUGUI _answerText = answerTemp.GetComponentInChildren<TextMeshProUGUI>();
                answerTemp.transform.SetParent(answersLayout);
                _answerText.text = answer.answerText;

                _answerObjects.Add(answerTemp);
            }
        }
    }

    public void ChangeDialog(Answer answer)
    {
        if (answer.answerType == "Bye")
        {
            _npcInteraction.CloseDialogMenu();
            return;
        }

        if (answer.answerType == "Confirm")
        {
            if (_neutralNPC.neutralNpcSO.npcQuest._currQuestStatus == "ֽו גûהאם")
            {
                _neutralNPC.neutralNpcSO.npcQuest._currQuestStatus = "ֲûהאם";
                _npcInteraction._playerQuests.SetQuest(_neutralNPC.neutralNpcSO.npcQuest);
                _neutralNPC.SetState(_neutralNPC.followQuestState);
            }
            _npcInteraction.CloseDialogMenu();
            return;
        }

        if (answer.answerType == "Cancel")
        {
            _npcInteraction.CloseDialogMenu();
            return;
        }

        if (answer.answerType == "Trade")
        {
            _npcInteraction.npcInventory.OpenInventory();
            _npcInteraction.CloseDialogMenu();
            return;
        }

        for (int i = 0; i < _dialogs.Length; i++)
        {
            if (answer.answerType == _dialogs[i].dialogType)
            {
                _dialogStatus = i;
                StartDialog();
                break;
            }
        }
    }

    private void ClearQuestDialog()
    {
        foreach (Dialog dialog in _dialogs)
        {
            if (dialog.dialogType == "Start")
            {
                foreach (Answer answer in dialog.playerAnswers)
                {
                    if (answer.answerType == "QuestStart")
                    {
                        answer.answerStatus = "Invisible";
                    }
                }
            }
        }
    }

    public void ResetQuestDialog()
    {
        foreach (Dialog dialog in _dialogs)
        {
            if (dialog.dialogType == "Start")
            {
                foreach (Answer answer in dialog.playerAnswers)
                {
                    if (answer.answerType == "QuestStart")
                    {
                        answer.answerStatus = "Visible";
                    }
                }
            }
        }
    }
}
