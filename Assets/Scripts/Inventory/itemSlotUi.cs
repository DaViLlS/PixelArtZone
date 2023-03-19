using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class itemSlotUi : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image slotBackGround;
    [SerializeField] private Color standartColor;
    [SerializeField] private Color pointerEnterColor;

    public void OnPointerEnter(PointerEventData eventData)
    {
        ChangeColor(pointerEnterColor);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ChangeColor(standartColor);
    }

    private void ChangeColor(Color color)
    {
        slotBackGround.color = color;
    }
}
