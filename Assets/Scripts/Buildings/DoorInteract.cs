using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : MonoBehaviour
{
    [SerializeField] private Sprite _closedDoorSprite;
    [SerializeField] private Sprite _openedDoorSprite;
    [SerializeField] private bool openedDoorOnStart;
    [SerializeField] private BoxCollider2D _doorCollider;
    private SpriteRenderer _doorSprite;
    private bool _openedDoor;

    private void Start()
    {
        _openedDoor = openedDoorOnStart;
        _doorSprite = GetComponentInParent<SpriteRenderer>();
        //_doorCollider = GetComponentInParent<BoxCollider2D>();

        if (_openedDoor)
        {
            _openedDoor = false;
            _doorSprite.sprite = _openedDoorSprite;
            _doorCollider.isTrigger = true;
        }
        else
        {
            _openedDoor = true;
            _doorSprite.sprite = _closedDoorSprite;
            _doorCollider.isTrigger = false;
        }
    }

    public void InteractWithDoor()
    {
        if (_openedDoor)
        {
            _openedDoor = false;
            _doorSprite.sprite = _openedDoorSprite;
            _doorCollider.isTrigger = true;
        }
        else
        {
            _openedDoor = true;
            _doorSprite.sprite = _closedDoorSprite;
            _doorCollider.isTrigger = false;
        }
    }
}
