using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ActiveQuestUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questNameText;
    [SerializeField] private TextMeshProUGUI questDescriptionText;
    [SerializeField] private GameObject objcetivesPanel;

    private void Awake()
    {
        questNameText.text = "";
        questDescriptionText.text = "������� ���, ����� � �� �������";
    }

    public void SetActiveQuestUi(string questName, string questDescr)
    {
        questNameText.text = questName;
        questDescriptionText.text = questDescr;
    }
}
