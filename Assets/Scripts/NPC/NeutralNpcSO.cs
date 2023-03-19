using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="NPC/NeutralNPC")]
public class NeutralNpcSO : ScriptableObject
{
    [SerializeField] public string neutralName;
    [SerializeField] public int neutralHealth;
    [SerializeField] public float neutralSpeed;
    [SerializeField] public Quest npcQuest;
}
