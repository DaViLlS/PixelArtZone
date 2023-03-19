using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingExit : MonoBehaviour
{
    [SerializeField] private SpriteRenderer door;
    [SerializeField] private Tilemap backWalls;
    [SerializeField] private Tilemap frontWalls;
    [SerializeField] private Tilemap roof;
    private Color _frontWallsColor;
    private Color _roofColor;
    private Color _doorColor;

    private void Awake()
    {
        _frontWallsColor = frontWalls.color;
        _roofColor = roof.color;
        _doorColor = door.color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _frontWallsColor.a = 1f;
            _roofColor.a = 1f;
            //doorColor.a = 1f;

            frontWalls.color = _frontWallsColor;
            roof.color = _roofColor;
            //door.color = doorColor;

            Camera.main.orthographicSize = 6.6f;
        }
    }
}
