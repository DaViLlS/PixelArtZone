using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DialogSystem/Answer")]
public class Answer : ScriptableObject
{
    [SerializeField] public string answerText;
    [SerializeField] public string answerType;
    [SerializeField] public string answerStatus;
}
