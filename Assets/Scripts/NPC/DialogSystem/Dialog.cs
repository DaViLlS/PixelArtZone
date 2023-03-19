using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="DialogSystem/Dialog")]
public class Dialog : ScriptableObject
{
    [SerializeField] public string npcText;
    [SerializeField] public Answer[] playerAnswers;
    [SerializeField] public string dialogType;
}
