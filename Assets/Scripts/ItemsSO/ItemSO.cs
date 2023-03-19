using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemSO : ScriptableObject
{
    [SerializeField] public string itemName;
    [SerializeField] public Sprite icon;
    [SerializeField] public Sprite iconUI;
    [SerializeField] public Material material;
    [SerializeField] public bool isStackable;
    [SerializeField] public int itemCost;
}
