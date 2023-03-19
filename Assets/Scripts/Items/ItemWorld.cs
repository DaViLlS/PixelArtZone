using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    [SerializeField] public ItemSO itemSo;
    private SpriteRenderer itemWorldSprite;
    public int amount;
    private int curentAmount;

    private void Awake()
    {
        itemWorldSprite = GetComponent<SpriteRenderer>();
        if (amount > 0)
            SetCurrentCount(amount);
    }

    private void Start()
    {
        itemWorldSprite.sprite = itemSo.icon;
        itemWorldSprite.material = itemSo.material;
        //if (itemSo is ArtefactSO artefact)
        //    Debug.Log(artefact.artefactType);
    }

    public void SetCurrentCount(int cnt)
    {
        curentAmount = cnt;
    }

    public int GetCurrentCount()
    {
        return curentAmount;
    }
}