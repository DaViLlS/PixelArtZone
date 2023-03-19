using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingEnterExit : MonoBehaviour
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
            _frontWallsColor = frontWalls.color;
            _roofColor = roof.color;
            _doorColor = door.color;

            _frontWallsColor.a = 0.2f;
            _roofColor.a = 0.2f;
            //doorColor.a = 0.3f;

            frontWalls.color = _frontWallsColor;
            roof.color = _roofColor;
            //door.color = doorColor;

            Camera.main.orthographicSize = 3.3f;
        }
    }
}
